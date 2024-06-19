using FTOptix.Core;

namespace MOAB.Optix.Core.Builder.Helpers;

public static class HmiColors
{
    public static Color PrimaryColor => GetHexToColor("#FFFFFF4D");

    public static Color PrimaryBorder => GetHexToColor("#4dd8ff97");

    public static Color SecondaryColor => GetHexToColor("003399");

    public static Color SecondaryBorder => GetHexToColor("#000000");

    public static Color Failure => GetHexToColor("#000000");

    public static Color Ready => GetHexToColor("#000000");

    public static Color Alert => GetHexToColor("#000000");

    public static Color Black => GetHexToColor("#000000");

    public static Color White => GetHexToColor("#ffffff");

    public static Color DarkGrey => GetHexToColor("#000000");

    public static Color Transparent => GetHexToColor("#ffffff00");

    private static Color GetHexToColor(string hex)
    {
        if (hex.StartsWith("#"))
        {
            hex = hex.Substring(1);
        }

        byte red = Convert.ToByte(hex.Substring(0, 2), 16);
        byte green = Convert.ToByte(hex.Substring(2, 2), 16);
        byte blue = Convert.ToByte(hex.Substring(4, 2), 16);
        byte alpha = hex.Length > 6 ? Convert.ToByte(hex.Substring(6, 2), 16) : (byte)255;

        return new Color(alpha, red, green, blue);
    }
}
