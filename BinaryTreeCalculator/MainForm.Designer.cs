using System.Runtime.InteropServices;

namespace BinaryTreeCalculator
{
    partial class MainForm
    {
        // Import the SendMessage and ReleaseCapture methods from user32.dll
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        // Constant for moving the window
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void minimizeButton_Click(object sender, EventArgs e) 
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void closeButton_Click(object sender, EventArgs e) 
        {
            this.Close();
        }

        private void navBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture(); // Release the current mouse capture
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0); // Simulate dragging
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            navBar = new Panel();
            minimizeButton = new Button();
            closeButton = new Button();
            appName = new Label();
            leftPanel = new Panel();
            secondaryTextBox = new TextBox();
            primaryTextBox = new TextBox();
            calculatorButtonGrid = new TableLayoutPanel();
            button0 = new RoundedButton();
            button1 = new RoundedButton();
            button2 = new RoundedButton();
            button3 = new RoundedButton();
            button4 = new RoundedButton();
            button5 = new RoundedButton();
            button6 = new RoundedButton();
            button7 = new RoundedButton();
            button8 = new RoundedButton();
            button9 = new RoundedButton();
            buttonDot = new RoundedButton();
            buttonPlus = new RoundedButton();
            buttonMinus = new RoundedButton();
            buttonMultiply = new RoundedButton();
            buttonDivide = new RoundedButton();
            buttonOpen = new RoundedButton();
            buttonClose = new RoundedButton();
            buttonAC = new RoundedButton();
            buttonEqual = new RoundedButton();
            buttonDel = new RoundedButton();
            separationLine = new PictureBox();
            rightPanel = new Panel();
            treeViewerLabel = new Label();
            navBar.SuspendLayout();
            leftPanel.SuspendLayout();
            calculatorButtonGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)separationLine).BeginInit();
            rightPanel.SuspendLayout();
            SuspendLayout();
            // 
            // navBar
            // 
            navBar.AccessibleName = "Panel";
            navBar.BackColor = Color.FromArgb(46, 46, 46);
            navBar.Controls.Add(minimizeButton);
            navBar.Controls.Add(closeButton);
            navBar.Controls.Add(appName);
            navBar.Dock = DockStyle.Top;
            navBar.ForeColor = Color.FromArgb(255, 255, 255);
            navBar.Location = new Point(0, 0);
            navBar.Margin = new Padding(0);
            navBar.Name = "navBar";
            navBar.Size = new Size(800, 32);
            navBar.TabIndex = 0;
            navBar.MouseDown += navBar_MouseDown;
            // 
            // minimizeButton
            // 
            minimizeButton.BackColor = Color.Transparent;
            minimizeButton.Dock = DockStyle.Right;
            minimizeButton.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            minimizeButton.FlatAppearance.BorderSize = 0;
            minimizeButton.FlatStyle = FlatStyle.Flat;
            minimizeButton.Font = new Font("Arial", 10F);
            minimizeButton.ImageAlign = ContentAlignment.MiddleRight;
            minimizeButton.Location = new Point(680, 0);
            minimizeButton.Margin = new Padding(0);
            minimizeButton.Name = "minimizeButton";
            minimizeButton.Size = new Size(60, 32);
            minimizeButton.TabIndex = 2;
            minimizeButton.Text = "_";
            minimizeButton.UseVisualStyleBackColor = false;
            minimizeButton.Click += minimizeButton_Click;
            // 
            // closeButton
            // 
            closeButton.BackColor = Color.Transparent;
            closeButton.Dock = DockStyle.Right;
            closeButton.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Font = new Font("Arial", 10F);
            closeButton.ImageAlign = ContentAlignment.MiddleRight;
            closeButton.Location = new Point(740, 0);
            closeButton.Margin = new Padding(0);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(60, 32);
            closeButton.TabIndex = 1;
            closeButton.Text = "X";
            closeButton.UseVisualStyleBackColor = false;
            closeButton.Click += closeButton_Click;
            // 
            // appName
            // 
            appName.AccessibleName = "AppLabel";
            appName.AutoSize = true;
            appName.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            appName.Location = new Point(12, 7);
            appName.Name = "appName";
            appName.Size = new Size(161, 16);
            appName.TabIndex = 1;
            appName.Text = "Binary Tree Calculator";
            // 
            // leftPanel
            // 
            leftPanel.Controls.Add(secondaryTextBox);
            leftPanel.Controls.Add(primaryTextBox);
            leftPanel.Controls.Add(calculatorButtonGrid);
            leftPanel.Location = new Point(0, 32);
            leftPanel.Margin = new Padding(0);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size(320, 468);
            leftPanel.TabIndex = 2;
            // 
            // secondaryTextBox
            // 
            secondaryTextBox.BackColor = Color.Black;
            secondaryTextBox.BorderStyle = BorderStyle.None;
            secondaryTextBox.Font = new Font("Arial", 16F);
            secondaryTextBox.ForeColor = Color.DimGray;
            secondaryTextBox.Location = new Point(25, 20);
            secondaryTextBox.Name = "secondaryTextBox";
            secondaryTextBox.Size = new Size(270, 25);
            secondaryTextBox.TabIndex = 3;
            secondaryTextBox.TextAlign = HorizontalAlignment.Right;
            // 
            // primaryTextBox
            // 
            primaryTextBox.BackColor = Color.Black;
            primaryTextBox.BorderStyle = BorderStyle.None;
            primaryTextBox.Font = new Font("Arial", 24F);
            primaryTextBox.ForeColor = Color.White;
            primaryTextBox.Location = new Point(25, 51);
            primaryTextBox.Name = "primaryTextBox";
            primaryTextBox.Size = new Size(270, 37);
            primaryTextBox.TabIndex = 2;
            primaryTextBox.TextAlign = HorizontalAlignment.Right;
            // 
            // calculatorButtonGrid
            // 
            calculatorButtonGrid.ColumnCount = 4;
            calculatorButtonGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            calculatorButtonGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            calculatorButtonGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            calculatorButtonGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            calculatorButtonGrid.Controls.Add(button0, 1, 4);
            calculatorButtonGrid.Controls.Add(button1, 0, 3);
            calculatorButtonGrid.Controls.Add(button2, 1, 3);
            calculatorButtonGrid.Controls.Add(button3, 2, 3);
            calculatorButtonGrid.Controls.Add(button4, 0, 2);
            calculatorButtonGrid.Controls.Add(button5, 1, 2);
            calculatorButtonGrid.Controls.Add(button6, 2, 2);
            calculatorButtonGrid.Controls.Add(button7, 0, 1);
            calculatorButtonGrid.Controls.Add(button8, 1, 1);
            calculatorButtonGrid.Controls.Add(button9, 2, 1);
            calculatorButtonGrid.Controls.Add(buttonDot, 0, 4);
            calculatorButtonGrid.Controls.Add(buttonPlus, 3, 3);
            calculatorButtonGrid.Controls.Add(buttonMinus, 3, 2);
            calculatorButtonGrid.Controls.Add(buttonMultiply, 3, 1);
            calculatorButtonGrid.Controls.Add(buttonDivide, 3, 0);
            calculatorButtonGrid.Controls.Add(buttonOpen, 1, 0);
            calculatorButtonGrid.Controls.Add(buttonClose, 2, 0);
            calculatorButtonGrid.Controls.Add(buttonAC, 0, 0);
            calculatorButtonGrid.Controls.Add(buttonEqual, 3, 4);
            calculatorButtonGrid.Controls.Add(buttonDel, 2, 4);
            calculatorButtonGrid.Dock = DockStyle.Bottom;
            calculatorButtonGrid.Location = new Point(0, 98);
            calculatorButtonGrid.Margin = new Padding(20);
            calculatorButtonGrid.Name = "calculatorButtonGrid";
            calculatorButtonGrid.Padding = new Padding(20, 0, 20, 20);
            calculatorButtonGrid.RowCount = 5;
            calculatorButtonGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            calculatorButtonGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            calculatorButtonGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            calculatorButtonGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            calculatorButtonGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            calculatorButtonGrid.Size = new Size(320, 370);
            calculatorButtonGrid.TabIndex = 1;
            // 
            // button0
            // 
            button0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button0.BackColor = Color.FromArgb(46, 46, 46);
            button0.BorderColor = Color.Black;
            button0.BorderRadius = 60;
            button0.BorderSize = 0;
            button0.FlatAppearance.BorderSize = 0;
            button0.FlatStyle = FlatStyle.Flat;
            button0.Font = new Font("Arial", 16F);
            button0.ForeColor = Color.White;
            button0.Location = new Point(95, 285);
            button0.Margin = new Padding(5);
            button0.Name = "button0";
            button0.OriginalBackColor = Color.FromArgb(46, 46, 46);
            button0.Size = new Size(60, 60);
            button0.TabIndex = 0;
            button0.Text = "0";
            button0.UseVisualStyleBackColor = false;
            button0.Click += button0_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(46, 46, 46);
            button1.BorderColor = Color.Black;
            button1.BorderRadius = 60;
            button1.BorderSize = 0;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Arial", 16F);
            button1.ForeColor = Color.White;
            button1.Location = new Point(25, 215);
            button1.Margin = new Padding(5);
            button1.Name = "button1";
            button1.OriginalBackColor = Color.FromArgb(46, 46, 46);
            button1.Size = new Size(60, 60);
            button1.TabIndex = 1;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button2.BackColor = Color.FromArgb(46, 46, 46);
            button2.BorderColor = Color.Black;
            button2.BorderRadius = 60;
            button2.BorderSize = 0;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Arial", 16F);
            button2.ForeColor = Color.White;
            button2.Location = new Point(95, 215);
            button2.Margin = new Padding(5);
            button2.Name = "button2";
            button2.OriginalBackColor = Color.FromArgb(46, 46, 46);
            button2.Size = new Size(60, 60);
            button2.TabIndex = 2;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button3.BackColor = Color.FromArgb(46, 46, 46);
            button3.BorderColor = Color.Black;
            button3.BorderRadius = 60;
            button3.BorderSize = 0;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Arial", 16F);
            button3.ForeColor = Color.White;
            button3.Location = new Point(165, 215);
            button3.Margin = new Padding(5);
            button3.Name = "button3";
            button3.OriginalBackColor = Color.FromArgb(46, 46, 46);
            button3.Size = new Size(60, 60);
            button3.TabIndex = 3;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button4.BackColor = Color.FromArgb(46, 46, 46);
            button4.BorderColor = Color.Black;
            button4.BorderRadius = 60;
            button4.BorderSize = 0;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Arial", 16F);
            button4.ForeColor = Color.White;
            button4.Location = new Point(25, 145);
            button4.Margin = new Padding(5);
            button4.Name = "button4";
            button4.OriginalBackColor = Color.FromArgb(46, 46, 46);
            button4.Size = new Size(60, 60);
            button4.TabIndex = 4;
            button4.Text = "4";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button5.BackColor = Color.FromArgb(46, 46, 46);
            button5.BorderColor = Color.Black;
            button5.BorderRadius = 60;
            button5.BorderSize = 0;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Arial", 16F);
            button5.ForeColor = Color.White;
            button5.Location = new Point(95, 145);
            button5.Margin = new Padding(5);
            button5.Name = "button5";
            button5.OriginalBackColor = Color.FromArgb(46, 46, 46);
            button5.Size = new Size(60, 60);
            button5.TabIndex = 5;
            button5.Text = "5";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button6.BackColor = Color.FromArgb(46, 46, 46);
            button6.BorderColor = Color.Black;
            button6.BorderRadius = 60;
            button6.BorderSize = 0;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Arial", 16F);
            button6.ForeColor = Color.White;
            button6.Location = new Point(165, 145);
            button6.Margin = new Padding(5);
            button6.Name = "button6";
            button6.OriginalBackColor = Color.FromArgb(46, 46, 46);
            button6.Size = new Size(60, 60);
            button6.TabIndex = 6;
            button6.Text = "6";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button7.BackColor = Color.FromArgb(46, 46, 46);
            button7.BorderColor = Color.Black;
            button7.BorderRadius = 60;
            button7.BorderSize = 0;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Arial", 16F);
            button7.ForeColor = Color.White;
            button7.Location = new Point(25, 75);
            button7.Margin = new Padding(5);
            button7.Name = "button7";
            button7.OriginalBackColor = Color.FromArgb(46, 46, 46);
            button7.Size = new Size(60, 60);
            button7.TabIndex = 7;
            button7.Text = "7";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button8.BackColor = Color.FromArgb(46, 46, 46);
            button8.BorderColor = Color.Black;
            button8.BorderRadius = 60;
            button8.BorderSize = 0;
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Arial", 16F);
            button8.ForeColor = Color.White;
            button8.Location = new Point(95, 75);
            button8.Margin = new Padding(5);
            button8.Name = "button8";
            button8.OriginalBackColor = Color.FromArgb(46, 46, 46);
            button8.Size = new Size(60, 60);
            button8.TabIndex = 8;
            button8.Text = "8";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button9.BackColor = Color.FromArgb(46, 46, 46);
            button9.BorderColor = Color.Black;
            button9.BorderRadius = 60;
            button9.BorderSize = 0;
            button9.FlatAppearance.BorderSize = 0;
            button9.FlatStyle = FlatStyle.Flat;
            button9.Font = new Font("Arial", 16F);
            button9.ForeColor = Color.White;
            button9.Location = new Point(165, 75);
            button9.Margin = new Padding(5);
            button9.Name = "button9";
            button9.OriginalBackColor = Color.FromArgb(46, 46, 46);
            button9.Size = new Size(60, 60);
            button9.TabIndex = 9;
            button9.Text = "9";
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            // 
            // buttonDot
            // 
            buttonDot.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonDot.BackColor = Color.FromArgb(46, 46, 46);
            buttonDot.BorderColor = Color.Black;
            buttonDot.BorderRadius = 60;
            buttonDot.BorderSize = 0;
            buttonDot.FlatAppearance.BorderSize = 0;
            buttonDot.FlatStyle = FlatStyle.Flat;
            buttonDot.Font = new Font("Arial", 16F);
            buttonDot.ForeColor = Color.White;
            buttonDot.Location = new Point(25, 285);
            buttonDot.Margin = new Padding(5);
            buttonDot.Name = "buttonDot";
            buttonDot.OriginalBackColor = Color.FromArgb(46, 46, 46);
            buttonDot.Size = new Size(60, 60);
            buttonDot.TabIndex = 10;
            buttonDot.Text = ".";
            buttonDot.UseVisualStyleBackColor = false;
            buttonDot.Click += buttonDot_Click;
            // 
            // buttonPlus
            // 
            buttonPlus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonPlus.BackColor = Color.FromArgb(30, 30, 30);
            buttonPlus.BorderColor = Color.Black;
            buttonPlus.BorderRadius = 60;
            buttonPlus.BorderSize = 0;
            buttonPlus.FlatAppearance.BorderSize = 0;
            buttonPlus.FlatStyle = FlatStyle.Flat;
            buttonPlus.Font = new Font("Arial", 16F);
            buttonPlus.ForeColor = Color.White;
            buttonPlus.Location = new Point(235, 215);
            buttonPlus.Margin = new Padding(5);
            buttonPlus.Name = "buttonPlus";
            buttonPlus.OriginalBackColor = Color.FromArgb(30, 30, 30);
            buttonPlus.Size = new Size(60, 60);
            buttonPlus.TabIndex = 11;
            buttonPlus.Text = "+";
            buttonPlus.UseVisualStyleBackColor = false;
            buttonPlus.Click += buttonPlus_Click;
            // 
            // buttonMinus
            // 
            buttonMinus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonMinus.BackColor = Color.FromArgb(30, 30, 30);
            buttonMinus.BorderColor = Color.Black;
            buttonMinus.BorderRadius = 60;
            buttonMinus.BorderSize = 0;
            buttonMinus.FlatAppearance.BorderSize = 0;
            buttonMinus.FlatStyle = FlatStyle.Flat;
            buttonMinus.Font = new Font("Arial", 16F);
            buttonMinus.ForeColor = Color.White;
            buttonMinus.Location = new Point(235, 145);
            buttonMinus.Margin = new Padding(5);
            buttonMinus.Name = "buttonMinus";
            buttonMinus.OriginalBackColor = Color.FromArgb(30, 30, 30);
            buttonMinus.Size = new Size(60, 60);
            buttonMinus.TabIndex = 12;
            buttonMinus.Text = "-";
            buttonMinus.UseVisualStyleBackColor = false;
            buttonMinus.Click += buttonMinus_Click;
            // 
            // buttonMultiply
            // 
            buttonMultiply.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonMultiply.BackColor = Color.FromArgb(30, 30, 30);
            buttonMultiply.BorderColor = Color.Black;
            buttonMultiply.BorderRadius = 60;
            buttonMultiply.BorderSize = 0;
            buttonMultiply.FlatAppearance.BorderSize = 0;
            buttonMultiply.FlatStyle = FlatStyle.Flat;
            buttonMultiply.Font = new Font("Arial", 16F);
            buttonMultiply.ForeColor = Color.White;
            buttonMultiply.Location = new Point(235, 75);
            buttonMultiply.Margin = new Padding(5);
            buttonMultiply.Name = "buttonMultiply";
            buttonMultiply.OriginalBackColor = Color.FromArgb(30, 30, 30);
            buttonMultiply.Size = new Size(60, 60);
            buttonMultiply.TabIndex = 13;
            buttonMultiply.Text = "x";
            buttonMultiply.UseVisualStyleBackColor = false;
            buttonMultiply.Click += buttonMultiply_Click;
            // 
            // buttonDivide
            // 
            buttonDivide.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonDivide.BackColor = Color.FromArgb(30, 30, 30);
            buttonDivide.BorderColor = Color.Black;
            buttonDivide.BorderRadius = 60;
            buttonDivide.BorderSize = 0;
            buttonDivide.FlatAppearance.BorderSize = 0;
            buttonDivide.FlatStyle = FlatStyle.Flat;
            buttonDivide.Font = new Font("Arial", 16F);
            buttonDivide.ForeColor = Color.White;
            buttonDivide.Location = new Point(235, 5);
            buttonDivide.Margin = new Padding(5);
            buttonDivide.Name = "buttonDivide";
            buttonDivide.OriginalBackColor = Color.FromArgb(30, 30, 30);
            buttonDivide.Size = new Size(60, 60);
            buttonDivide.TabIndex = 14;
            buttonDivide.Text = "/";
            buttonDivide.UseVisualStyleBackColor = false;
            buttonDivide.Click += buttonDivide_Click;
            // 
            // buttonOpen
            // 
            buttonOpen.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonOpen.BackColor = Color.FromArgb(30, 30, 30);
            buttonOpen.BorderColor = Color.Black;
            buttonOpen.BorderRadius = 60;
            buttonOpen.BorderSize = 0;
            buttonOpen.FlatAppearance.BorderSize = 0;
            buttonOpen.FlatStyle = FlatStyle.Flat;
            buttonOpen.Font = new Font("Arial", 16F);
            buttonOpen.ForeColor = Color.White;
            buttonOpen.Location = new Point(95, 5);
            buttonOpen.Margin = new Padding(5);
            buttonOpen.Name = "buttonOpen";
            buttonOpen.OriginalBackColor = Color.FromArgb(30, 30, 30);
            buttonOpen.Size = new Size(60, 60);
            buttonOpen.TabIndex = 15;
            buttonOpen.Text = "(";
            buttonOpen.UseVisualStyleBackColor = false;
            buttonOpen.Click += buttonOpen_Click;
            // 
            // buttonClose
            // 
            buttonClose.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonClose.BackColor = Color.FromArgb(30, 30, 30);
            buttonClose.BorderColor = Color.Black;
            buttonClose.BorderRadius = 60;
            buttonClose.BorderSize = 0;
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.Font = new Font("Arial", 16F);
            buttonClose.ForeColor = Color.White;
            buttonClose.Location = new Point(165, 5);
            buttonClose.Margin = new Padding(5);
            buttonClose.Name = "buttonClose";
            buttonClose.OriginalBackColor = Color.FromArgb(30, 30, 30);
            buttonClose.Size = new Size(60, 60);
            buttonClose.TabIndex = 16;
            buttonClose.Text = ")";
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Click += buttonClose_Click;
            // 
            // buttonAC
            // 
            buttonAC.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonAC.BackColor = Color.FromArgb(30, 30, 30);
            buttonAC.BorderColor = Color.Black;
            buttonAC.BorderRadius = 60;
            buttonAC.BorderSize = 0;
            buttonAC.FlatAppearance.BorderSize = 0;
            buttonAC.FlatStyle = FlatStyle.Flat;
            buttonAC.Font = new Font("Arial", 16F);
            buttonAC.ForeColor = Color.White;
            buttonAC.Location = new Point(25, 5);
            buttonAC.Margin = new Padding(5);
            buttonAC.Name = "buttonAC";
            buttonAC.OriginalBackColor = Color.FromArgb(30, 30, 30);
            buttonAC.Size = new Size(60, 60);
            buttonAC.TabIndex = 17;
            buttonAC.Text = "AC";
            buttonAC.UseVisualStyleBackColor = false;
            buttonAC.Click += buttonAC_Click;
            // 
            // buttonEqual
            // 
            buttonEqual.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonEqual.BackColor = Color.FromArgb(135, 89, 49);
            buttonEqual.BorderColor = Color.Black;
            buttonEqual.BorderRadius = 60;
            buttonEqual.BorderSize = 0;
            buttonEqual.FlatAppearance.BorderSize = 0;
            buttonEqual.FlatStyle = FlatStyle.Flat;
            buttonEqual.Font = new Font("Arial", 16F);
            buttonEqual.ForeColor = Color.White;
            buttonEqual.Location = new Point(235, 285);
            buttonEqual.Margin = new Padding(5);
            buttonEqual.Name = "buttonEqual";
            buttonEqual.OriginalBackColor = Color.FromArgb(135, 89, 49);
            buttonEqual.Size = new Size(60, 60);
            buttonEqual.TabIndex = 18;
            buttonEqual.Text = "=";
            buttonEqual.UseVisualStyleBackColor = false;
            buttonEqual.Click += buttonEqual_Click;
            // 
            // buttonDel
            // 
            buttonDel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonDel.BackColor = Color.FromArgb(30, 30, 30);
            buttonDel.BorderColor = Color.Black;
            buttonDel.BorderRadius = 60;
            buttonDel.BorderSize = 0;
            buttonDel.FlatAppearance.BorderSize = 0;
            buttonDel.FlatStyle = FlatStyle.Flat;
            buttonDel.Font = new Font("Arial", 16F);
            buttonDel.ForeColor = Color.White;
            buttonDel.Location = new Point(165, 285);
            buttonDel.Margin = new Padding(5);
            buttonDel.Name = "buttonDel";
            buttonDel.OriginalBackColor = Color.FromArgb(30, 30, 30);
            buttonDel.Size = new Size(60, 60);
            buttonDel.TabIndex = 19;
            buttonDel.Text = "Del";
            buttonDel.UseVisualStyleBackColor = false;
            buttonDel.Click += buttonDel_Click;
            // 
            // separationLine
            // 
            separationLine.BackColor = Color.FromArgb(30, 30, 30);
            separationLine.Location = new Point(0, 0);
            separationLine.Name = "separationLine";
            separationLine.Size = new Size(2, 468);
            separationLine.TabIndex = 4;
            separationLine.TabStop = false;
            // 
            // rightPanel
            // 
            rightPanel.Controls.Add(treeViewerLabel);
            rightPanel.Controls.Add(separationLine);
            rightPanel.Location = new Point(320, 32);
            rightPanel.Name = "rightPanel";
            rightPanel.Size = new Size(480, 468);
            rightPanel.TabIndex = 5;
            rightPanel.Paint += rightPanel_Paint;
            // 
            // treeViewerLabel
            // 
            treeViewerLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            treeViewerLabel.AutoSize = true;
            treeViewerLabel.Font = new Font("Arial", 16F, FontStyle.Bold);
            treeViewerLabel.Location = new Point(172, 20);
            treeViewerLabel.Name = "treeViewerLabel";
            treeViewerLabel.Size = new Size(135, 26);
            treeViewerLabel.TabIndex = 0;
            treeViewerLabel.Text = "Tree Viewer";
            treeViewerLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(800, 500);
            Controls.Add(rightPanel);
            Controls.Add(leftPanel);
            Controls.Add(navBar);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "MainForm";
            Text = "Binary Tree Calculator";
            navBar.ResumeLayout(false);
            navBar.PerformLayout();
            leftPanel.ResumeLayout(false);
            leftPanel.PerformLayout();
            calculatorButtonGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)separationLine).EndInit();
            rightPanel.ResumeLayout(false);
            rightPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel navBar;
        private Label appName;
        private Button minimizeButton;
        private Button closeButton;
        private Panel leftPanel;
        private TableLayoutPanel calculatorButtonGrid;
        private RoundedButton button0;
        private RoundedButton button1;
        private RoundedButton button2;
        private RoundedButton button3;
        private RoundedButton button4;
        private RoundedButton button5;
        private RoundedButton button6;
        private RoundedButton button7;
        private RoundedButton button8;
        private RoundedButton button9;
        private RoundedButton buttonDot;
        private RoundedButton buttonPlus;
        private RoundedButton buttonMinus;
        private RoundedButton buttonMultiply;
        private RoundedButton buttonDivide;
        private RoundedButton buttonOpen;
        private RoundedButton buttonClose;
        private RoundedButton buttonAC;
        private RoundedButton buttonEqual;
        private RoundedButton buttonDel;
        private TextBox primaryTextBox;
        private TextBox secondaryTextBox;
        private PictureBox separationLine;
        private Panel rightPanel;
        private Label treeViewerLabel;
    }
}
