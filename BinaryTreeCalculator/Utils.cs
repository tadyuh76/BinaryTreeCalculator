namespace BinaryTreeCalculator;

public static class Utils
{
    /// <summary>
    /// Làm sáng màu bằng cách trộn với màu trắng theo tỷ lệ phần trăm chỉ định.
    /// </summary>
    /// <param name="color">Màu gốc cần làm sáng.</param>
    /// <param name="percentage">Tỷ lệ làm sáng (từ 0 đến 1).</param>
    /// <returns>Một màu mới đã được làm sáng.</returns>
    public static Color LightenColor(Color color, float percentage)
    {
        // Đảm bảo giá trị phần trăm nằm trong khoảng từ 0 đến 1
        percentage = Math.Clamp(percentage, 0, 1);

        // Tính toán màu sáng hơn bằng cách nội suy với màu trắng
        int r = (int)(color.R + (255 - color.R) * percentage); // Thành phần đỏ
        int g = (int)(color.G + (255 - color.G) * percentage); // Thành phần xanh lá
        int b = (int)(color.B + (255 - color.B) * percentage); // Thành phần xanh dương

        // Trả về màu mới với các giá trị thành phần đã tính toán
        return Color.FromArgb(color.A, r, g, b);
    }
}
