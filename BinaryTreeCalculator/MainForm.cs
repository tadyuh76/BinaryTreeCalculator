namespace BinaryTreeCalculator;

public partial class MainForm : Form
{
    public string Expression = ""; // Biểu thức hiện tại
    public bool IsResultDisplayed = false; // Cờ xác định xem kết quả đã được hiển thị hay chưa
    public BinaryTree BinaryTree = new(); // Cây nhị phân để xử lý biểu thức

    public MainForm()
    {
        InitializeComponent();
        InitializeCustomUI(); // Khởi tạo giao diện người dùng
        UpdateCaretPosition(0); // Đặt vị trí con trỏ ban đầu
    }

    private void InitializeCustomUI()
    {
        // Thiết lập giao diện ban đầu cho hộp văn bản phụ (ẩn kết quả)
        secondaryTextBox.ForeColor = Color.Transparent;
        secondaryTextBox.Font = new Font(secondaryTextBox.Font.FontFamily, 12);
    }

    private void UpdateExpression(string value)
    {
        // Xác định vị trí con trỏ hiện tại trong hộp văn bản chính
        int caretPosition = primaryTextBox.SelectionStart;

        // Kiểm tra trạng thái nếu kết quả đang hiển thị và giá trị mới là số
        if (IsResultDisplayed && char.IsDigit(value[0]))
        {
            primaryTextBox.Clear(); // Xóa hộp văn bản
            Expression = ""; // Đặt lại biểu thức
            IsResultDisplayed = false; // Đặt lại cờ
            caretPosition = 0; // Đặt con trỏ ở đầu văn bản
        }
        else if (IsResultDisplayed)
        {
            Expression = primaryTextBox.Text; // Chuyển kết quả thành biểu thức mới
            IsResultDisplayed = false;
            caretPosition = primaryTextBox.Text.Length; // Đặt con trỏ ở cuối văn bản
        }

        // Thêm giá trị mới vào biểu thức và hộp văn bản chính
        primaryTextBox.Text = primaryTextBox.Text.Insert(caretPosition, value);
        Expression = Expression.Insert(caretPosition, value);

        // Di chuyển con trỏ sau khi thêm giá trị
        UpdateCaretPosition(caretPosition + value.Length);

        // Đặt lại kiểu giao diện của kết quả
        secondaryTextBox.ForeColor = Color.Black;
        secondaryTextBox.Font = new Font(secondaryTextBox.Font.FontFamily, 16);

        // Đánh giá lại biểu thức
        EvaluateExpression();
    }

    // Các sự kiện click cho các nút trên giao diện
    private void button0_Click(object sender, EventArgs e) => UpdateExpression("0");
    private void button1_Click(object sender, EventArgs e) => UpdateExpression("1");
    private void button2_Click(object sender, EventArgs e) => UpdateExpression("2");
    private void button3_Click(object sender, EventArgs e) => UpdateExpression("3");
    private void button4_Click(object sender, EventArgs e) => UpdateExpression("4");
    private void button5_Click(object sender, EventArgs e) => UpdateExpression("5");
    private void button6_Click(object sender, EventArgs e) => UpdateExpression("6");
    private void button7_Click(object sender, EventArgs e) => UpdateExpression("7");
    private void button8_Click(object sender, EventArgs e) => UpdateExpression("8");
    private void button9_Click(object sender, EventArgs e) => UpdateExpression("9");
    private void buttonDot_Click(object sender, EventArgs e) => UpdateExpression(".");
    private void buttonPlus_Click(object sender, EventArgs e) => UpdateExpression(Constants.PlusSign);
    private void buttonMinus_Click(object sender, EventArgs e) => UpdateExpression(Constants.MinusSign);
    private void buttonMultiply_Click(object sender, EventArgs e) => UpdateExpression(Constants.MultiplicationSign);
    private void buttonDivide_Click(object sender, EventArgs e) => UpdateExpression(Constants.DivisionSign);
    private void powerButton_Click(object sender, EventArgs e) => UpdateExpression(Constants.PowerSign);
    private void sqrtButton_Click(object sender, EventArgs e) => UpdateExpression(Constants.SqrtSign);
    private void buttonOpen_Click(object sender, EventArgs e) => UpdateExpression("(");
    private void buttonClose_Click(object sender, EventArgs e) => UpdateExpression(")");

    private void buttonAC_Click(object sender, EventArgs e)
    {
        // Xóa toàn bộ biểu thức và đặt lại giao diện
        primaryTextBox.Clear();
        secondaryTextBox.Clear();
        Expression = "";
        IsResultDisplayed = false;
        InitializeCustomUI();
        BinaryTree = new(); // Tạo lại cây nhị phân
        RefreshRightPanel(); // Làm mới giao diện cây nhị phân
    }

    private void buttonDel_Click(object sender, EventArgs e)
    {
        // Xóa ký tự trước con trỏ
        var caretPosition = primaryTextBox.SelectionStart;
        if (caretPosition > 0)
        {
            primaryTextBox.Text = primaryTextBox.Text.Remove(caretPosition - 1, 1);
            Expression = Expression.Remove(caretPosition - 1, 1);
            UpdateCaretPosition(caretPosition - 1);
            EvaluateExpression(); // Đánh giá lại biểu thức sau khi xóa
        }
    }

    private void buttonEqual_Click(object sender, EventArgs e)
    {
        // Xử lý khi nhấn nút "="
        if (Expression == "") return;

        try
        {
            double result = BinaryTree.EvaluateExpression(Expression); // Tính kết quả từ biểu thức

            primaryTextBox.Text = result.ToString(); // Hiển thị kết quả
            secondaryTextBox.Text = Expression.ToString(); // Hiển thị biểu thức
            secondaryTextBox.ForeColor = Constants.LightGreyColor; // Đổi màu biểu thức phụ
            secondaryTextBox.Font = new Font(secondaryTextBox.Font.FontFamily, 16);

            Expression = result.ToString(); // Cập nhật biểu thức thành kết quả
            IsResultDisplayed = true;
            RefreshRightPanel(); // Làm mới giao diện cây nhị phân
        }
        catch (Exception)
        {
            primaryTextBox.Text = "Error"; // Hiển thị lỗi
            secondaryTextBox.Clear();
            Expression = "";
            IsResultDisplayed = false;
        }
    }

    private void rightPanel_Paint(object sender, PaintEventArgs e)
    {
        if (BinaryTree?.Root == null) return;

        // Vẽ cây nhị phân trên giao diện
        Graphics g = e.Graphics;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        int panelWidth = rightPanel.Width;
        int panelHeight = rightPanel.Height;

        int nodeRadius = 22; // Bán kính của nút
        int verticalSpacing = 50; // Khoảng cách dọc giữa các cấp

        int treeHeight = GetTreeDepth(BinaryTree.Root) * verticalSpacing; // Chiều cao của cây
        int startY = (panelHeight - treeHeight) / 2; // Điều chỉnh để căn giữa cây

        DrawNode(g, BinaryTree.Root, panelWidth / 2, startY, panelWidth / 4, nodeRadius, verticalSpacing); // Bắt đầu vẽ từ nút gốc
    }

    // Vẽ nút trên cây nhị phân
    // - Gửi Graphics để vẽ, node hiện tại, vị trí x/y của nút, khoảng cách ngang/dọc, bán kính nút
    private void DrawNode(Graphics g, BinaryTreeNode node, int x, int y, int horizontalSpacing, int nodeRadius, int verticalSpacing)
    {
        if (node == null) return;

        // Bút để vẽ các đường nối
        Pen linePen = new Pen(Constants.LightGreyColor, 2f);

        // Vẽ nhánh con bên trái
        if (node.Left != null)
        {
            int childX = x - horizontalSpacing;
            int childY = y + verticalSpacing;

            // Vẽ đường nối với nút con bên trái
            g.DrawLine(linePen, x, y, childX, childY - nodeRadius + 5);

            // Đệ quy vẽ cây con bên trái
            DrawNode(g, node.Left, childX, childY, horizontalSpacing / 2, nodeRadius, verticalSpacing);
        }

        // Vẽ nhánh con bên phải
        if (node.Right != null)
        {
            int childX = x + horizontalSpacing;
            int childY = y + verticalSpacing;

            // Vẽ đường nối với nút con bên phải
            g.DrawLine(linePen, x, y, childX, childY - nodeRadius + 5);

            // Đệ quy vẽ cây con bên phải
            DrawNode(g, node.Right, childX, childY, horizontalSpacing / 2, nodeRadius, verticalSpacing);
        }

        // Xác định màu cho nút hiện tại
        Brush nodeBrush = IsExpressionNode(node) ? new SolidBrush(Constants.ExpressionColor)
                                                 : new SolidBrush(Constants.OperantColor);

        // Vẽ hình tròn biểu thị nút
        RectangleF circleBounds = new RectangleF(x - nodeRadius, y - nodeRadius, 2 * nodeRadius, 2 * nodeRadius);
        g.FillEllipse(nodeBrush, circleBounds);
        g.DrawEllipse(Pens.Transparent, circleBounds);

        // Hiển thị giá trị của nút
        StringFormat format = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };
        var truncatedVal = IsExpressionNode(node) ? node.Value : RoundedToFourChars(node.Value);
        var fontSize = IsExpressionNode(node) ? 14 : 10;
        g.DrawString(truncatedVal, new Font("Consolas", fontSize), Brushes.White, circleBounds, format);
    }

    // Rút gọn giá trị số thành 4 ký tự
    string RoundedToFourChars(string number)
    {
        var valid = double.TryParse(number, out double parsed);
        if (parsed < 0) return Math.Round(parsed, 2).ToString();

        return valid ? parsed.ToString("0.###").Length <= 5
            ? parsed.ToString("0.###")
            : parsed.ToString("0E+0")
            : "Invalid";
    }

    // Làm mới bảng bên phải
    private void RefreshRightPanel()
    {
        rightPanel.Invalidate(); // Yêu cầu vẽ lại bảng
        rightPanel.Update(); // Xử lý ngay lập tức yêu cầu vẽ lại
    }

    // Đánh giá biểu thức và hiển thị kết quả
    private void EvaluateExpression()
    {
        try
        {
            string result = BinaryTree.EvaluateExpression(Expression).ToString();

            if (result != primaryTextBox.Text)
            {
                secondaryTextBox.Text = result.ToString();
                secondaryTextBox.ForeColor = Constants.LightGreyColor;
                secondaryTextBox.Font = new Font(secondaryTextBox.Font.FontFamily, 16);
            }

        }
        catch (Exception)
        {
            secondaryTextBox.Clear();
        }
    }

    // Tính độ sâu của cây nhị phân
    private int GetTreeDepth(BinaryTreeNode? node)
    {
        if (node == null) return 0;
        return 1 + Math.Max(GetTreeDepth(node.Left), GetTreeDepth(node.Right));
    }

    // Kiểm tra nút có phải là nút biểu thức không
    private bool IsExpressionNode(BinaryTreeNode node)
    {
        return Constants.AllSigns.Contains(node.Value);
    }

    // Hiệu ứng hover cho nút minimize
    private void minimizeButton_MouseEnter(object sender, EventArgs e)
    {
        minimizeButton.BackColor = Constants.GreyColor;
    }

    private void minimizeButton_MouseLeave(object sender, EventArgs e)
    {
        minimizeButton.BackColor = Constants.DarkGreyColor;
    }

    // Hiệu ứng hover cho nút close
    private void closeButton_MouseEnter(object sender, EventArgs e)
    {
        closeButton.BackColor = Constants.GreyColor;
    }

    private void closeButton_MouseLeave(object sender, EventArgs e)
    {
        closeButton.BackColor = Constants.DarkGreyColor;
    }

    // Xử lý nhập liệu trong primaryTextBox
    private void primaryTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        int caretPosition = primaryTextBox.SelectionStart; // Vị trí con trỏ hiện tại
        string? input = GetCharacterFromKeyEvent(e); // Lấy ký tự từ sự kiện phím

        if (!string.IsNullOrEmpty(input))
        {
            InsertAtCaret(input, caretPosition);
            e.SuppressKeyPress = true; // Ngăn hành vi mặc định của phím
        }
        else if (e.KeyCode == Keys.Back && caretPosition > 0) // Xử lý phím Backspace
        {
            RemoveAtCaret(caretPosition - 1);
            e.SuppressKeyPress = true;
        }
        else if (e.KeyCode == Keys.Left) // Xử lý phím mũi tên trái
        {
            MoveCaret(-1);
            e.SuppressKeyPress = true;
        }
        else if (e.KeyCode == Keys.Right) // Xử lý phím mũi tên phải
        {
            MoveCaret(1);
            e.SuppressKeyPress = true;
        }
        else
        {
            e.SuppressKeyPress = true; // Ngăn tất cả các phím khác
        }
    }

    private string? GetCharacterFromKeyEvent(KeyEventArgs e)
    {
        // Xử lý các phím có Shift (khi người dùng nhấn Shift + phím)
        if (e.Shift)
        {
            return e.KeyCode switch
            {
                Keys.D0 => ")", // Shift + 0 để nhập dấu đóng ngoặc
                Keys.D9 => "(", // Shift + 9 để nhập dấu mở ngoặc
                Keys.Oemplus => "+", // Shift + '=' để nhập dấu cộng
                Keys.D8 => Constants.MultiplicationSign, // Shift + 8 để nhập dấu nhân (thay thế bằng ký hiệu đã định nghĩa)
                Keys.D6 => Constants.PowerSign, // Shift + 6 để nhập ký hiệu mũ (thay thế bằng ký hiệu đã định nghĩa)
                _ => null // Trả về null nếu phím không được hỗ trợ
            };
        }

        // Xử lý các phím không có Shift (nhập trực tiếp ký tự tương ứng)
        return e.KeyCode switch
        {
            Keys.D0 => "0", // Phím 0
            Keys.D1 => "1", // Phím 1
            Keys.D2 => "2", // Phím 2
            Keys.D3 => "3", // Phím 3
            Keys.D4 => "4", // Phím 4
            Keys.D5 => "5", // Phím 5
            Keys.D6 => "6", // Phím 6
            Keys.D7 => "7", // Phím 7
            Keys.D8 => "8", // Phím 8
            Keys.D9 => "9", // Phím 9
            Keys.OemMinus => "-", // Phím '-' (dấu trừ)
            Keys.OemPeriod => ".", // Phím '.' (dấu chấm)
            Keys.OemQuestion => Constants.DivisionSign, // Phím '/' thay thế bằng ký hiệu chia đã định nghĩa
            _ => null // Trả về null nếu phím không được hỗ trợ
        };
    }

    private void InsertAtCaret(string input, int caretPosition)
    {
        // Thêm một ký tự vào vị trí con trỏ hiện tại trong biểu thức
        UpdateExpression(input);
    }

    private void RemoveAtCaret(int caretPosition)
    {
        // Xóa ký tự tại vị trí con trỏ
        primaryTextBox.Text = primaryTextBox.Text.Remove(caretPosition, 1); // Xóa ký tự khỏi TextBox
        Expression = Expression.Remove(caretPosition, 1); // Xóa ký tự khỏi biểu thức
        UpdateCaretPosition(caretPosition); // Cập nhật vị trí con trỏ sau khi xóa
        EvaluateExpression(); // Đánh giá lại biểu thức để cập nhật kết quả
    }

    private void UpdateCaretPosition(int position)
    {
        // Cập nhật vị trí con trỏ trong TextBox
        primaryTextBox.SelectionStart = position; // Thiết lập vị trí con trỏ
        primaryTextBox.SelectionLength = 0; // Đảm bảo không có văn bản nào được chọn
        primaryTextBox.Focus(); // Giữ TextBox trong trạng thái được chọn
    }

    private void MoveCaret(int offset)
    {
        // Di chuyển con trỏ theo khoảng cách chỉ định (offset)
        int newPosition = Math.Clamp(primaryTextBox.SelectionStart + offset, 0, primaryTextBox.Text.Length);
        UpdateCaretPosition(newPosition); // Cập nhật vị trí con trỏ mới
    }

    // Xử lý sự kiện khi người dùng nhấn nút di chuyển con trỏ sang trái
    private void leftButton_Click(object sender, EventArgs e) => MoveCaret(-1);

    // Xử lý sự kiện khi người dùng nhấn nút di chuyển con trỏ sang phải
    private void rightButton_Click(object sender, EventArgs e) => MoveCaret(1);
}