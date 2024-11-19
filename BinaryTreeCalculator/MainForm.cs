using System;
using System.Drawing.Drawing2D;

namespace BinaryTreeCalculator
{
    public partial class MainForm : Form
    {
        public string Expression = "";

        public MainForm()
        {
            InitializeComponent();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            expressionTextBox.Text += "0";
            Expression += "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            expressionTextBox.Text += "1";
            Expression += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            expressionTextBox.Text += "2";
            Expression += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            expressionTextBox.Text += "3";
            Expression += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            expressionTextBox.Text += "4";
            Expression += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            expressionTextBox.Text += "5";
            Expression += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            expressionTextBox.Text += "6";
            Expression += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            expressionTextBox.Text += "7";
            Expression += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            expressionTextBox.Text += "8";
            Expression += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            expressionTextBox.Text += "9";
            Expression += "9";
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            expressionTextBox.Text += ".";
            Expression += ".";
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            expressionTextBox.Text += "+";
            Expression += "+";
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            expressionTextBox.Text += "-";
            Expression += "-";
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            expressionTextBox.Text += "*";
            Expression += "*";
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            expressionTextBox.Text += "/";
            Expression += "/";
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            expressionTextBox.Text += "(";
            Expression += "(";
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            expressionTextBox.Text += ")";
            Expression += ")";
        }

        private void buttonAC_Click(object sender, EventArgs e)
        {
            expressionTextBox.Clear();
            Expression = "";
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (expressionTextBox.Text.Length > 0)
            {
                expressionTextBox.Text = expressionTextBox.Text.Remove(expressionTextBox.Text.Length - 1);
                Expression = Expression.Remove(Expression.Length - 1);
            }
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            try
            {
                var binaryTree = new BinaryTree();
                double result = binaryTree.EvaluateExpression(Expression);
                expressionTextBox.Text = result.ToString();
                Expression = result.ToString(); // Update the expression with the result
            }
            catch (Exception ex)
            {
                expressionTextBox.Text = "Error";
                Expression = "";
            }
        }
    }
}
