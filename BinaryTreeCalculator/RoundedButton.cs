using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace BinaryTreeCalculator;

[DesignerCategory("Code")]
public class RoundedButton : Button
{
    // Thuộc tính tùy chỉnh
    public int BorderRadius { get; set; } = 60; // Độ bo tròn của nút
    public int BorderSize { get; set; } = 0; // Độ dày viền của nút
    public Color BorderColor { get; set; } = Color.Black; // Màu viền của nút

    public Color OriginalBackColor { get; set; } = Constants.GreyColor; // Màu nền mặc định của nút

    // Constructor mặc định
    public RoundedButton()
    {
        // Thiết lập kiểu dáng và giao diện mặc định
        FlatStyle = FlatStyle.Flat; // Loại bỏ giao diện nổi
        Font = new Font("Consolas", 16F); // Thiết lập font chữ
        ForeColor = Color.White; // Màu chữ
        Size = new Size(60, 60); // Kích thước nút
        Margin = new Padding(5); // Khoảng cách bên ngoài
        Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right; // Cố định vị trí
        FlatAppearance.BorderSize = 0; // Loại bỏ viền mặc định

        Cursor = Cursors.Hand; // Hiển thị con trỏ tay khi di chuột

        // Gắn các sự kiện hover
        this.MouseEnter += CustomButton_MouseEnter; // Sự kiện khi di chuột vào nút
        this.MouseLeave += CustomButton_MouseLeave; // Sự kiện khi di chuột ra khỏi nút
    }

    // Constructor tuỳ chỉnh
    public RoundedButton(Color backColor)
    {
        // Thiết lập kiểu dáng và giao diện mặc định
        FlatStyle = FlatStyle.Flat; // Loại bỏ giao diện nổi
        Font = new Font("Consolas", 16F); // Thiết lập font chữ
        ForeColor = Color.White; // Màu chữ
        Size = new Size(60, 60); // Kích thước nút
        Margin = new Padding(5); // Khoảng cách bên ngoài
        Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right; // Cố định vị trí
        FlatAppearance.BorderSize = 0; // Loại bỏ viền mặc định
        BackColor = backColor; // Màu nền tuỳ chỉnh
        OriginalBackColor = backColor; // Lưu màu nền gốc

        Cursor = Cursors.Hand; // Hiển thị con trỏ tay khi di chuột

        // Gắn các sự kiện hover
        this.MouseEnter += CustomButton_MouseEnter; // Sự kiện khi di chuột vào nút
        this.MouseLeave += CustomButton_MouseLeave; // Sự kiện khi di chuột ra khỏi nút
    }

    // Xử lý sự kiện khi di chuột vào nút
    private void CustomButton_MouseEnter(object sender, System.EventArgs e)
    {
        this.BackColor = Utils.LightenColor(OriginalBackColor, 0.1f); // Làm sáng màu nền khi hover
    }

    // Xử lý sự kiện khi di chuột ra khỏi nút
    private void CustomButton_MouseLeave(object sender, System.EventArgs e)
    {
        this.BackColor = OriginalBackColor; // Khôi phục màu nền gốc
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        // Loại bỏ cách vẽ mặc định
        base.OnPaintBackground(pevent);

        Graphics g = pevent.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias; // Làm mịn các góc

        // Xác định hình chữ nhật của nút
        Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

        // Tạo đường dẫn cho các góc bo tròn
        GraphicsPath path = new GraphicsPath();
        int radius = BorderRadius;
        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90); // Góc trên bên trái
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90); // Góc trên bên phải
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90); // Góc dưới bên phải
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90); // Góc dưới bên trái
        path.CloseAllFigures(); // Đóng đường dẫn

        // Đặt vùng của nút khớp với đường dẫn bo tròn
        this.Region = new Region(path);

        // Vẽ nền bo tròn
        using (Brush brush = new SolidBrush(this.BackColor))
        {
            g.FillPath(brush, path);
        }

        // Vẽ viền
        Pen pen = new Pen(BorderColor, BorderSize); // Tạo bút vẽ viền
        g.DrawPath(pen, path); // Vẽ viền theo đường dẫn bo tròn

        // Vẽ văn bản
        StringFormat stringFormat = new StringFormat
        {
            Alignment = StringAlignment.Center, // Căn giữa theo chiều ngang
            LineAlignment = StringAlignment.Center // Căn giữa theo chiều dọc
        };
        g.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), rect, stringFormat); // Vẽ văn bản
    }
}
