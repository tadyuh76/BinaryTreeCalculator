using System;
using System.Drawing;

namespace BinaryTreeCalculator
{
    public partial class MainForm : Form
    {
        public string Expression = "";
        public bool IsResultDisplayed = false; // Flag to track if result is displayed

        public MainForm()
        {
            InitializeComponent();
            InitializeCustomUI();
        }

        private void InitializeCustomUI()
        {
            secondaryTextBox.ForeColor = Color.Transparent; // Hide result by default
            secondaryTextBox.Font = new Font(secondaryTextBox.Font.FontFamily, 12); // Smaller font for hidden state
        }

        private void UpdateExpression(string value)
        {
            if (IsResultDisplayed && char.IsDigit(value[0])) // Reset on new digit
            {
                primaryTextBox.Clear();
                Expression = "";
                IsResultDisplayed = false;
            }
            else if (IsResultDisplayed) // Continue with current result
            {
                Expression = primaryTextBox.Text; // Convert result to the new expression
                IsResultDisplayed = false;
            }

            primaryTextBox.Text += value;
            Expression += value;

            // Reset result UI
            secondaryTextBox.ForeColor = Color.Black;
            secondaryTextBox.Font = new Font(secondaryTextBox.Font.FontFamily, 16);
        }

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
        private void buttonPlus_Click(object sender, EventArgs e) => UpdateExpression("+");
        private void buttonMinus_Click(object sender, EventArgs e) => UpdateExpression("-");
        private void buttonMultiply_Click(object sender, EventArgs e) => UpdateExpression("*");
        private void buttonDivide_Click(object sender, EventArgs e) => UpdateExpression("/");
        private void buttonOpen_Click(object sender, EventArgs e) => UpdateExpression("(");
        private void buttonClose_Click(object sender, EventArgs e) => UpdateExpression(")");

        private void buttonAC_Click(object sender, EventArgs e)
        {
            primaryTextBox.Clear();
            secondaryTextBox.Clear();
            Expression = "";
            IsResultDisplayed = false;
            InitializeCustomUI();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (primaryTextBox.Text.Length > 0)
            {
                primaryTextBox.Text = primaryTextBox.Text.Remove(primaryTextBox.Text.Length - 1);
                Expression = Expression.Remove(Expression.Length - 1);
            }
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            try
            {
                var binaryTree = new BinaryTree();
                double result = binaryTree.EvaluateExpression(Expression);

                // Update primary text box UI
                primaryTextBox.Text = result.ToString();

                // Update secondary text box UI
                secondaryTextBox.Text = Expression.ToString();
                secondaryTextBox.ForeColor = Constants.LightGreyColor;
                secondaryTextBox.Font = new Font(secondaryTextBox.Font.FontFamily, 16);

                Expression = result.ToString(); // Update expression to the result
                IsResultDisplayed = true;
            }
            catch (Exception)
            {
                primaryTextBox.Text = "Error";
                secondaryTextBox.Clear();
                Expression = "";
                IsResultDisplayed = false;
            }
        }
    }
}
