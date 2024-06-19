using FTOptix.UI;
using static MOAB.Optix.Core.Builder.Helpers.HmiStyledElements;
using static MOAB.Optix.Core.Builder.Helpers.TreeShortcuts;

namespace MOAB.Optix.Core.Builder.Helpers;

//TODO - Have seperate icon and image classes
public static class Icons
{
    #region Icon Images
    public static Image MikronAutomationLogo = MakeDefaultImage("MikronLogo", "MikronAutomationLogo.svg");
    public static Image BaseBackground = MakeDefaultImage("BaseBackground", "MikronGradient.jpg");
    public static Image PageBackground = MakeDefaultImage("BasePageBackground", "MikronBaseBackground.jpg");
    public static Image GradientBackground = MakeDefaultImage("GradientBackgroundImage", "MikronGradientBackground.svg");

    public static Image StationIcon10Error = MakeDefaultImage("StationIcon10Error", "Red10.svg");
    public static Image StationIcon6Error = MakeDefaultImage("StationIcon6Error", "Red6.svg");
    public static Image StationIcon7Warning = MakeDefaultImage("StationIcon7EWarning", "Orange7.svg");

    public static Image ReadyIcon = MakeDefaultImage("ReadyIcon", "ready.svg");
    public static Image ErrorIcon = MakeDefaultImage("ErrorIcon", "Error.svg");
    public static Image WarningIcon = MakeDefaultImage("WarningIcon", "warning.svg");

    #endregion

    #region Icon Image paths

    public static string ReadyIconPath = GetRelativeImagePath("ready.svg");
    public static string ErrorIconPath = GetRelativeImagePath("Error.svg");
    public static string WarningIconPath = GetRelativeImagePath("warning.svg");

    public static string StationIcon10ErrorPath = GetRelativeImagePath("Red10.svg");
    public static string StationIcon6ErrorPath = GetRelativeImagePath("Red6.svg");
    public static string StationIcon7WarningPath = GetRelativeImagePath("Orange7.svg");

    public static string HomeIconPath = GetRelativeImagePath("home.svg");
    public static string StationIconPath = GetRelativeImagePath("station.svg");
    public static string PlaceholderIconPath = GetRelativeImagePath("placeholder.svg");

    public static string StatusIconPath = GetRelativeImagePath("GearsWithStatus2.svg");
    public static string UserIconPath = GetRelativeImagePath("User.svg");
    public static string CamAngleIconPath = GetRelativeImagePath("CamAngle.svg");

    public static string EditIconPath = GetRelativeImagePath("edit.svg");

    #endregion
}
