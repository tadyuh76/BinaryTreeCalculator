using System.Diagnostics;

namespace BinaryTreeCalculator;

// Lớp đại diện cho một nút trong cây nhị phân
public class BinaryTreeNode
{
    public string Value { get; set; } // Giá trị của nút (toán hạng hoặc toán tử)
    public BinaryTreeNode? Left { get; set; } // Nút con bên trái
    public BinaryTreeNode? Right { get; set; } // Nút con bên phải

    public BinaryTreeNode(string value)
    {
        Value = value;
        Left = Right = null; // Ban đầu không có nút con
    }
}

// Lớp đại diện cho cây nhị phân
public class BinaryTree
{
    public BinaryTreeNode? Root { get; private set; } // Gốc của cây, để phục vụ trực quan hóa

    // Hàm tính toán giá trị biểu thức
    public double EvaluateExpression(string expression)
    {
        Root = BuildExpressionTree(expression); // Xây dựng cây biểu thức và gán vào Root
        var res = EvaluateTree(Root); // Tính giá trị từ cây
        return Math.Round(res, 10); // Làm tròn kết quả đến 10 chữ số thập phân
    }

    // Hàm xây dựng cây biểu thức từ chuỗi biểu thức
    private BinaryTreeNode BuildExpressionTree(string expression)
    {
        var tokens = Tokenize(expression); // Phân tích biểu thức thành các token
        var postfix = ConvertToPostfix(tokens); // Chuyển đổi sang dạng hậu tố

        // Ghi log token và hậu tố để kiểm tra
        Debug.Print("tokens: ");
        foreach (var t in tokens)
        {
            Debug.Print(t);
        }

        Debug.Print("postfix: ");
        foreach (var p in postfix)
        {
            Debug.Print(p);
        }
        return BuildTreeFromPostfix(postfix); // Xây dựng cây từ danh sách hậu tố
    }

    // Hàm tính toán giá trị của cây
    private double EvaluateTree(BinaryTreeNode? root)
    {
        if (root == null) return 0; // Nếu nút rỗng, trả về 0
        if (root.Left == null && root.Right == null) // Nút lá (toán hạng)
            return double.Parse(root.Value); // Trả về giá trị toán hạng

        double left = EvaluateTree(root.Left); // Đệ quy tính nhánh trái
        double right = EvaluateTree(root.Right); // Đệ quy tính nhánh phải

        // Tính toán giá trị dựa trên toán tử tại nút
        return root.Value switch
        {
            Constants.PlusSign => left + right,
            Constants.MinusSign => left - right,
            Constants.MultiplicationSign => left * right,
            Constants.DivisionSign => left / right,
            Constants.PowerSign => Math.Pow(left, right), // Lũy thừa
            Constants.SqrtSign => Math.Sqrt(left),       // Căn bậc hai (chỉ dùng nhánh trái)
            _ => throw new InvalidOperationException("Invalid operator") // Ném lỗi nếu toán tử không hợp lệ
        };
    }

    // Các hàm hỗ trợ: Phân tích token, chuyển đổi hậu tố, xây dựng cây
    private List<string> Tokenize(string expression)
    {
        var tokens = new List<string>();
        int i = 0;

        // Duyệt qua chuỗi biểu thức để tách token
        while (i < expression.Length)
        {
            if (char.IsDigit(expression[i]) || expression[i] == '.')
            {
                string number = "";
                while (i < expression.Length && (char.IsDigit(expression[i]) || expression[i] == '.'))
                {
                    number += expression[i];
                    i++;
                }
                tokens.Add(number); // Thêm số vào danh sách token
            }
            else if (expression[i] == '-' &&
                    (i == 0 || Constants.AllSignsExceptClosing.Contains(expression[i - 1].ToString())))
            {
                // Xử lý số âm
                string number = "-";
                i++;
                while (i < expression.Length && (char.IsDigit(expression[i]) || expression[i] == '.'))
                {
                    number += expression[i];
                    i++;
                }
                tokens.Add(number);
            }
            else if (expression[i] == '(')
            {
                // Thêm phép nhân ẩn trước dấu '(' nếu cần
                if (i > 0 && (char.IsDigit(expression[i - 1]) || expression[i - 1] == ')'))
                {
                    tokens.Add(Constants.MultiplicationSign);
                }
                tokens.Add(expression[i].ToString());
                i++;
            }
            else if (expression[i] == ')')
            {
                // Kiểm tra lỗi cú pháp (VD: (1+2)3 là không hợp lệ)
                if (i + 1 < expression.Length && char.IsDigit(expression[i + 1]))
                {
                    throw new InvalidOperationException("Syntax Error");
                }

                tokens.Add(expression[i].ToString());
                i++;
            }
            else if (expression[i].ToString() == Constants.SqrtSign)
            {
                // Thêm phép nhân ẩn trước căn bậc hai
                if (i > 0 && (char.IsDigit(expression[i - 1]) || expression[i - 1] == ')'))
                {
                    tokens.Add(Constants.MultiplicationSign);
                }

                tokens.Add(Constants.SqrtSign);
                i++;
            }
            else
            {
                tokens.Add(expression[i].ToString()); // Thêm toán tử vào danh sách
                i++;
            }
        }

        return tokens;
    }

    // Hàm chuyển đổi biểu thức từ dạng trung tố sang hậu tố
    private List<string> ConvertToPostfix(List<string> tokens)
    {
        var output = new List<string>();
        var operators = new MyStack<string>();
        var precedence = new Dictionary<string, int>
            {
                { Constants.PlusSign, 1 },
                { Constants.MinusSign, 1 },
                { Constants.MultiplicationSign, 2 },
                { Constants.DivisionSign, 2 },
                { Constants.PowerSign, 3 }, // Độ ưu tiên cao hơn
                { Constants.SqrtSign, 4 }  // Độ ưu tiên cao nhất
            };

        foreach (var token in tokens)
        {
            if (double.TryParse(token, out _))
            {
                output.Add(token); // Thêm số vào đầu ra
            }
            else if (token == Constants.SqrtSign)
            {
                operators.Push(token); // Đưa căn bậc hai vào stack toán tử
            }
            else if (token == "(")
            {
                operators.Push(token); // Đưa dấu '(' vào stack
            }
            else if (token == ")")
            {
                while (operators.Peek() != "(")
                    output.Add(operators.Pop()); // Đưa các toán tử ra khỏi stack
                operators.Pop(); // Bỏ dấu '(' khỏi stack
            }
            else
            {
                while (operators.Count > 0 &&
                    precedence.ContainsKey(operators.Peek()) &&
                    precedence[operators.Peek()] >= precedence[token]
                )
                {
                    output.Add(operators.Pop()); // Đưa các toán tử có độ ưu tiên cao hơn ra
                }
                operators.Push(token); // Đưa toán tử hiện tại vào stack
            }
        }

        while (operators.Count > 0)
            output.Add(operators.Pop()); // Đưa các toán tử còn lại ra khỏi stack

        return output;
    }

    // Hàm xây dựng cây từ danh sách hậu tố
    private BinaryTreeNode BuildTreeFromPostfix(List<string> postfix)
    {
        var stack = new MyStack<BinaryTreeNode>();

        foreach (var token in postfix)
        {
            if (double.TryParse(token, out _))
            {
                stack.Push(new BinaryTreeNode(token)); // Thêm nút lá (toán hạng)
            }
            else if (token == Constants.SqrtSign)
            {
                var operand = stack.Pop(); // Lấy một toán hạng
                stack.Push(new BinaryTreeNode(token) { Left = operand }); // Gán toán hạng vào nhánh trái
            }
            else
            {
                var right = stack.Pop(); // Lấy toán hạng bên phải
                var left = stack.Pop(); // Lấy toán hạng bên trái
                stack.Push(new BinaryTreeNode(token) { Left = left, Right = right }); // Tạo nút với toán tử
            }
        }

        return stack.Pop(); // Trả về nút gốc của cây
    }
}
