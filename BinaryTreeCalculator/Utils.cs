using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeCalculator;

public static class Utils
{
    public static Color LightenColor(Color color, float percentage)
    {
        // Clamp percentage between 0 and 1
        percentage = Math.Clamp(percentage, 0, 1);

        // Calculate lighter color by interpolating with white
        int r = (int)(color.R + (255 - color.R) * percentage);
        int g = (int)(color.G + (255 - color.G) * percentage);
        int b = (int)(color.B + (255 - color.B) * percentage);

        return Color.FromArgb(color.A, r, g, b);
    }
}
