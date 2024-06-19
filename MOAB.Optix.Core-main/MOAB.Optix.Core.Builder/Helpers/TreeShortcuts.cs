using FTOptix.Core;
using FTOptix.HMIProject;
using FTOptix.UI;
using UAManagedCore;

namespace MOAB.Optix.Core.Builder.Helpers;

public class TreeShortcuts
{
    /// <summary>
    /// Use to get the Folder, the key is the filepath without "/", "UI", "Model", or "Components"
    /// </summary>
    public static Dictionary<string, Folder> FolderLookupDictionary = new Dictionary<string, Folder>();
    public static List<string> UIFolderNamesListToCopyPasteInFolderEnums = new List<string>();
    public static List<string> ModelFolderNamesListToCopyPasteInFolderEnums = new List<string>();
    public static List<string> AllFolderPaths = new List<string>();

    public TreeShortcuts()
    {
    }

    public static void AddToMainWindow<T>(T args)
    {
        Project.Current.Get("UI/MainWindow").Add((IUANode)args);
    }

    public static void AddToLayoutTemplates<T>(T args)
    {
        Project.Current.Get("UI/Layout/Templates").Add((IUANode)args);
    }

    /// <summary>
    /// Use to retrieve a folder from the tree. Pass in the matching filepath enum
    /// Ex: if you want to get Model/Components/Objects/Alarm/ObjectInstances
    /// You would call FolderLookup(ModelFolders.ObjectsAlarmObjectInstances)
    /// </summary>
    /// <param name="folderName">Select from pre-generated list in Enumerations class</param>
    /// <returns>Existing folder from the tree</returns>
    public static Folder FolderEnumLookup(Enum folderName)
    {
        string folderNameString = folderName.ToString();
        if (FolderLookupDictionary.TryGetValue(folderNameString, out Folder folder))
        {
            return folder;
        }
        else
        {
            return InformationModel.Make<Folder>("temp");
        }
    }

    public static PanelLoader GetMainContentPanelLoader(bool resetPanel = false)
    {
        PanelLoader mainContentPanelLoader = Project.Current.Find<PanelLoader>("MainContentPanelLoader");
        if (resetPanel)
        {
            mainContentPanelLoader.Panel = null;
        }

        return mainContentPanelLoader;
    }

    public static Rectangle GetBackgroundOfPanelLoaderSection(string panelLoaderSectionBrowseName)
    {
        PanelLoader panelLoaderSection = Project.Current.Find<PanelLoader>(panelLoaderSectionBrowseName);
        Rectangle background = panelLoaderSection.Find<Rectangle>("Background");

        return background;
    }

    public static PanelLoader GetLeftDashboardPanelLoader(bool resetPanel = false, bool isHidden = false)
    {
        PanelLoader dashboardLeftPanelLoader = Project.Current.Find<PanelLoader>("DashboardLeftPanelLoader");
        return dashboardLeftPanelLoader;
    }

    public static PanelLoader GetRightDashboardPanelLoader(bool resetPanel = false, bool isHidden = false)
    {
        PanelLoader dashboardRightPanelLoader = Project.Current.Find<PanelLoader>("DashboardRightPanelLoader");
        if (resetPanel)
        {
            dashboardRightPanelLoader.Panel = null;
        }
        if (isHidden)
        {
            dashboardRightPanelLoader.Visible = false;
        }
        else
        {
            dashboardRightPanelLoader.Visible = true;
        }
        return dashboardRightPanelLoader;
    }

    public static void SetMainContentPanelLoaderPanel(PanelType newContentToLoad)
    {
        PanelLoader mainContentPanelLoader = Project.Current.Find<PanelLoader>("MainContentPanelLoader");
        mainContentPanelLoader.Panel = newContentToLoad.NodeId;
    }

    public static string GetRelativeImagePath(string imageName)
    {
        if (imageName.Contains("Images"))
        {
            Log.Error("imageName contains whole path when it should only be the image name");
        }

        string imageRelativePath = "Images/" + imageName;
        ResourceUri projectFileResourceUri = ResourceUri.FromProjectRelativePath(imageRelativePath);

        return projectFileResourceUri;
    }

    public static string CleanPathString(string folderPath)
    {
        string lookupName = folderPath;
        string[] stringsToRemove = { "/", "UI", "Model", "Components" };

        foreach (string item in stringsToRemove)
        {
            lookupName = lookupName.Replace(item, "");
        }

        return lookupName;
    }
}
