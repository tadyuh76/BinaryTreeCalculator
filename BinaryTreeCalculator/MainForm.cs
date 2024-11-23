using System;
using System.Drawing;

namespace BinaryTreeCalculator
{
    public partial class MainForm : Form
    {
        public string Expression = "";
        public bool IsResultDisplayed = false; // Flag to track if result is displayed
        public BinaryTree BinaryTree = new();

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

            EvaluateExpression();
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
        private void buttonMultiply_Click(object sender, EventArgs e) => UpdateExpression(Constants.MultiplicationSign);
        private void buttonDivide_Click(object sender, EventArgs e) => UpdateExpression(Constants.DivisionSign);
        private void buttonOpen_Click(object sender, EventArgs e) => UpdateExpression("(");
        private void buttonClose_Click(object sender, EventArgs e) => UpdateExpression(")");

        private void buttonAC_Click(object sender, EventArgs e)
        {
            primaryTextBox.Clear();
            secondaryTextBox.Clear();
            Expression = "";

            IsResultDisplayed = false;
            InitializeCustomUI();

            // Hide the Binary Tree in the right panel
            BinaryTree = new();
            RefreshRightPanel();

        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (primaryTextBox.Text.Length > 0)
            {
                primaryTextBox.Text = primaryTextBox.Text.Remove(primaryTextBox.Text.Length - 1);
                Expression = Expression.Remove(Expression.Length - 1);

                EvaluateExpression();
            }
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            try
            {
                double result = BinaryTree.EvaluateExpression(Expression);

                // Update primary text box UI
                primaryTextBox.Text = result.ToString();

                // Update secondary text box UI
                secondaryTextBox.Text = Expression.ToString();
                secondaryTextBox.ForeColor = Constants.LightGreyColor;
                secondaryTextBox.Font = new Font(secondaryTextBox.Font.FontFamily, 16);

                Expression = result.ToString(); // Update expression to the result
                IsResultDisplayed = true;

                // Update the Tree viewer
                RefreshRightPanel();
            }
            catch (Exception)
            {
                primaryTextBox.Text = "Error";
                secondaryTextBox.Clear();
                Expression = "";
                IsResultDisplayed = false;
            }
        }

        private void rightPanel_Paint(object sender, PaintEventArgs e)
        {
            if (BinaryTree?.Root == null) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int panelWidth = rightPanel.Width;
            int panelHeight = rightPanel.Height;

            int nodeRadius = 22; // Radius of each node circle
            int verticalSpacing = 50; // Vertical spacing between levels

            // Calculate the total height of the tree
            int treeHeight = GetTreeDepth(BinaryTree.Root) * verticalSpacing;

            // Adjust the starting Y coordinate to center the tree vertically
            int startY = (panelHeight - treeHeight) / 2;

            // Start drawing the tree from the root
            DrawNode(g, BinaryTree.Root, panelWidth / 2, startY, panelWidth / 4, nodeRadius, verticalSpacing);
        }

        private void DrawNode(Graphics g, BinaryTreeNode node, int x, int y, int horizontalSpacing, int nodeRadius, int verticalSpacing)
        {
            if (node == null) return;

            // Pen for drawing lines
            Pen linePen = new Pen(Constants.LightGreyColor, 2f);

            // Draw left child
            if (node.Left != null)
            {
                int childX = x - horizontalSpacing;
                int childY = y + verticalSpacing;

                // Draw line to left child
                g.DrawLine(linePen, x, y, childX, childY - nodeRadius + 5);

                // Recursively draw the left subtree
                DrawNode(g, node.Left, childX, childY, horizontalSpacing / 2, nodeRadius, verticalSpacing);
            }

            // Draw right child
            if (node.Right != null)
            {
                int childX = x + horizontalSpacing;
                int childY = y + verticalSpacing;

                // Draw line to right child
                g.DrawLine(linePen, x, y, childX, childY - nodeRadius + 5);

                // Recursively draw the right subtree
                DrawNode(g, node.Right, childX, childY, horizontalSpacing / 2, nodeRadius, verticalSpacing);
            }

            // Determine the color for the current node
            Brush nodeBrush = IsExpressionNode(node) ? new SolidBrush(Constants.ExpressionColor)
                                                 : new SolidBrush(Constants.OperantColor);

            // Draw the current node as a circle
            RectangleF circleBounds = new RectangleF(x - nodeRadius, y - nodeRadius, 2 * nodeRadius, 2 * nodeRadius);
            g.FillEllipse(nodeBrush, circleBounds);
            g.DrawEllipse(Pens.Transparent, circleBounds);

            // Draw the node's value
            StringFormat format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var truncatedVal = IsExpressionNode(node) ? node.Value : RoundedToFourChars(node.Value);
            var fontSize = IsExpressionNode(node) ? 14 : 10;
            g.DrawString(truncatedVal, new Font("Consolas", fontSize), Brushes.White, circleBounds, format);
        }

        string RoundedToFourChars(string number)
        {
            var valid = double.TryParse(number, out double parsed);
            if (parsed < 0) return Math.Round(parsed, 2).ToString();

            return valid ? parsed.ToString("0.###").Length <= 5
                ? parsed.ToString("0.###")
                : parsed.ToString("0E+0")
            : "Invalid";
        }

        private void RefreshRightPanel()
        {
            rightPanel.Invalidate(); // Request to redraw the panel
            rightPanel.Update(); // Force immediate processing of the redraw
        }

        private void EvaluateExpression()
        {
            try
            {
                double result = BinaryTree.EvaluateExpression(Expression);

                secondaryTextBox.Text = result.ToString();
                secondaryTextBox.ForeColor = Constants.LightGreyColor;
                secondaryTextBox.Font = new Font(secondaryTextBox.Font.FontFamily, 16);

            }
            catch (Exception)
            {
                secondaryTextBox.Clear();
            }
        }

        private int GetTreeDepth(BinaryTreeNode node)
        {
            if (node == null) return 0;
            return 1 + Math.Max(GetTreeDepth(node.Left), GetTreeDepth(node.Right));
        }

        private bool IsExpressionNode(BinaryTreeNode node)
        {
            return Constants.AllSigns.Contains(node.Value);
        }

        private void minimizeButton_MouseEnter(object sender, EventArgs e)
        {
            minimizeButton.BackColor = Constants.GreyColor;
        }

        private void minimizeButton_MouseLeave(object sender, EventArgs e)
        {
            minimizeButton.BackColor = Constants.DarkGreyColor;
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.BackColor = Constants.GreyColor;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.BackColor = Constants.DarkGreyColor;
        }
    }
}