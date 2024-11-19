using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BinaryTreeCalculator;
public class RoundedButton : Button
{
    // Properties for customization
    public int BorderRadius { get; set; } = 60;
    public int BorderSize { get; set; } = 0;
    public Color BorderColor { get; set; } = Color.Black;

    public Color OriginalBackColor { get; set; } = Constants.GreyColor;


    // Constructor to set default properties
    public RoundedButton(Color backColor)
    {
        // Set default styles and appearance
        FlatStyle = FlatStyle.Flat;
        Font = new Font("Arial", 16F);
        ForeColor = Color.White;
        Size = new Size(60, 60);
        Margin = new Padding(5);
        Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        FlatAppearance.BorderSize = 0; // Remove default border
        BackColor = backColor;
        OriginalBackColor = backColor;

        Cursor = Cursors.Hand;

        // Attach hover event handlers
        this.MouseEnter += CustomButton_MouseEnter;
        this.MouseLeave += CustomButton_MouseLeave;


    }

    // Event handler for mouse enter
    private void CustomButton_MouseEnter(object sender, System.EventArgs e)
    {
        this.BackColor = Utils.LightenColor(OriginalBackColor, 0.1f);
    }

    // Event handler for mouse leave
    private void CustomButton_MouseLeave(object sender, System.EventArgs e)
    {
        this.BackColor = OriginalBackColor;
    }


    protected override void OnPaint(PaintEventArgs pevent)
    {
        // Suppress default painting
        base.OnPaintBackground(pevent);
        //base.OnPaint(pevent);

        Graphics g = pevent.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        // Define the button's rectangle
        Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

        // Create a path for rounded corners
        GraphicsPath path = new GraphicsPath();
        int radius = BorderRadius;
        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
        path.CloseAllFigures();

        // Set the region of the button to match the rounded path
        this.Region = new Region(path);

        // Fill the rounded background
        using (Brush brush = new SolidBrush(this.BackColor))
        {
            g.FillPath(brush, path);
        }

        // Draw the border
        Pen pen = new Pen(BorderColor, BorderSize);
        g.DrawPath(pen, path);

        // Draw the text
        StringFormat stringFormat = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };
        g.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), rect, stringFormat);
    }
}
