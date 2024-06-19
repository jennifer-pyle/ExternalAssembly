using UAManagedCore;
using static MOAB.Optix.Core.Builder.Helpers.TreeShortcuts;

namespace MOAB.Optix.Core.Builder.Helpers;

public class LogHelper
{
    public LogHelper()
    {
    }

    public static void LogPathsForEnums()
    {
        string stringOfUIEnumsToCopy = "";
        string stringOfModelEnumsToCopy = "";

        foreach (string folderPath in AllFolderPaths)
        {
            if (folderPath.Contains("Model"))
            {
                stringOfModelEnumsToCopy = stringOfModelEnumsToCopy + "," + CleanPathString(folderPath);
            }
            else
            {
                stringOfUIEnumsToCopy = stringOfUIEnumsToCopy + "," + CleanPathString(folderPath);
            }
        }

        Log.Info("UI folder Enums to copy/paste ------------" + stringOfUIEnumsToCopy);
        Log.Info("Model folder Enums to copy/paste ------------" + stringOfModelEnumsToCopy);
    }
}
