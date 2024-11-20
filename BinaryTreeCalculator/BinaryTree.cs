using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BinaryTreeCalculator;

public class BinaryTreeNode
{
    public string Value { get; set; }
    public BinaryTreeNode Left { get; set; }
    public BinaryTreeNode Right { get; set; }

    public BinaryTreeNode(string value)
    {
        Value = value;
        Left = Right = null;
    }
}

public class BinaryTree
{
    public BinaryTreeNode Root { get; private set; } // Expose the tree's root for visualization

    public double EvaluateExpression(string expression)
    {
        Root = BuildExpressionTree(expression); // Build the tree and set Root
        var res = EvaluateTree(Root);
        return Math.Round(res, 10);
    }

    private BinaryTreeNode BuildExpressionTree(string expression)
    {
        var tokens = Tokenize(expression);
        var postfix = ConvertToPostfix(tokens);
        return BuildTreeFromPostfix(postfix);
    }

    private double EvaluateTree(BinaryTreeNode root)
    {
        if (root == null) return 0;
        if (root.Left == null && root.Right == null) // Leaf node
            return double.Parse(root.Value);

        double left = EvaluateTree(root.Left);
        double right = EvaluateTree(root.Right);

        return root.Value switch
        {
            "+" => left + right,
            "-" => left - right,
            "*" => left * right,
            "/" => left / right,
            _ => throw new InvalidOperationException("Invalid operator")
        };
    }

    // Helpers (Tokenization, Postfix conversion, Tree building)
    private List<string> Tokenize(string expression)
    {
        var tokens = new List<string>();
        int i = 0;

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
                tokens.Add(number);
            }
            else
            {
                tokens.Add(expression[i].ToString());
                i++;
            }
        }

        return tokens;
    }

    private List<string> ConvertToPostfix(List<string> tokens)
    {
        var output = new List<string>();
        var operators = new Stack<string>();
        var precedence = new Dictionary<string, int> { { "+", 1 }, { "-", 1 }, { "*", 2 }, { "/", 2 } };

        foreach (var token in tokens)
        {
            if (double.TryParse(token, out _))
            {
                output.Add(token);
            }
            else if (token == "(")
            {
                operators.Push(token);
            }
            else if (token == ")")
            {
                while (operators.Peek() != "(")
                    output.Add(operators.Pop());
                operators.Pop();
            }
            else
            {
                while (operators.Count > 0 && precedence.ContainsKey(operators.Peek()) &&
                       precedence[operators.Peek()] >= precedence[token])
                    output.Add(operators.Pop());
                operators.Push(token);
            }
        }

        while (operators.Count > 0)
            output.Add(operators.Pop());

        return output;
    }

    private BinaryTreeNode BuildTreeFromPostfix(List<string> postfix)
    {
        var stack = new Stack<BinaryTreeNode>();

        foreach (var token in postfix)
        {
            if (double.TryParse(token, out _))
            {
                stack.Push(new BinaryTreeNode(token));
            }
            else
            {
                var right = stack.Pop();
                var left = stack.Pop();
                var node = new BinaryTreeNode(token) { Left = left, Right = right };
                stack.Push(node);
            }
        }

        return stack.Pop();
    }


}
