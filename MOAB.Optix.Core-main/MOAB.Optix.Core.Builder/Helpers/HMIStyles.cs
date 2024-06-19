using FTOptix.UI;

namespace MOAB.Optix.Core.Builder.Helpers;

public static class HmiStyles
{
    //Eventually add StyleSheets instead
    //check if there's a built in method for accessing "DefaultStyleSheet"
    public static float HeaderHeight = 50;
    public static float SidebarWidth = 50;
    public static VerticalAlignment HeaderVerticalAlignment = VerticalAlignment.Top;
    public static HorizontalAlignment SidebarHorizontalAlignment = HorizontalAlignment.Left;

    public static float StandardIconHeight = 40;
    public static float StandardIconWidth = 40;
    public static float StandardButtonHeight = 50;
    public static float StandardButtonWidth = 50;

    public static float SmallIconHeight = 20;
    public static float SmallIconWidth = 20;
    public static float SmallButtonHeight = 20;
    public static float SmallButtonWidth = 20;
    public static float SmallItemFontSize = SmallIconHeight;

    public static float AlarmItemHeight = 20;
    public static float AlarmItemWidth = 20;

    public static float StationIconHeight = 80;
    public static float StationIconWidth = 80;
    public static float StatusIconHeight = 80;
    public static float StatusIconWidth = 80;

    public static float ButtonFontSize = 16;
    public static float ButtonWidth = 40;

    public static float LocalNavigationButtonHeight = 20;
    public static float LocalNavigationButtonWidth = 80;
    public static float SelectedLocalNavigationButtonHeight = 100;
    public static float SelectedLocalNavigationButtonWidth = 100;
    public static float HorizontalDividerLineHeight = 2;

    //Return to discuss
    public static VerticalAlignment VerticalTop = VerticalAlignment.Top;
    public static VerticalAlignment VerticalBottom = VerticalAlignment.Bottom;
    public static VerticalAlignment VerticalCenter = VerticalAlignment.Center;
    public static VerticalAlignment VerticalStretch = VerticalAlignment.Stretch;

    public static HorizontalAlignment HorizontalLeft = HorizontalAlignment.Left;
    public static HorizontalAlignment HorizontalRight = HorizontalAlignment.Right;
    public static HorizontalAlignment HorizontalCenter = HorizontalAlignment.Center;
    public static HorizontalAlignment HorizontalStretch = HorizontalAlignment.Stretch;
}