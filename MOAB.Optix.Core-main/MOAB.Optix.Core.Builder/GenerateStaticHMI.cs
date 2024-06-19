using FTOptix.HMIProject;
using FTOptix.UI;
using MOAB.Optix.Core.Builder.Helpers;
using MOAB.Optix.Core.Builder.Pages.Home;
using MOAB.Optix.Core.Builder.Pages.Station;
using MOAB.Optix.Core.Builder.Templates;
using UAManagedCore;
using static MOAB.Optix.Core.Builder.Helpers.Enumerations;
using static MOAB.Optix.Core.Builder.Helpers.HmiStyledElements;
using static MOAB.Optix.Core.Builder.Helpers.HmiStyles;
using static MOAB.Optix.Core.Builder.Helpers.Icons;
using static MOAB.Optix.Core.Builder.Helpers.TemplateInstanceGenerator;
using static MOAB.Optix.Core.Builder.Helpers.TreeShortcuts;


namespace MOAB.Optix.Core.Builder;


public class GenerateStaticHMI
{
    private Header header;
    private Sidebar sidebar;
    private Alarms alarms;
    private PerformanceItem performanceItem;
    private LocalPageNavigation localPageNavigation;

    private Layouts layouts = new Layouts();
    private Home homeView = new Home();
    private StationView stationView = new StationView();
    private MOAB.Optix.Core.Builder.FolderSetup.FolderSetup folderSetup = new MOAB.Optix.Core.Builder.FolderSetup.FolderSetup();
    private CleanProject cleanProject = new CleanProject();

    private PanelLoader HeaderPanelLoader = MakeDefaultPanelLoader("HeaderPanelLoader");
    private PanelLoader SidebarPanelLoader = MakeDefaultPanelLoader("SidebarPanelLoader");
    private PanelLoader PagePanelLoader = MakeDefaultPanelLoader("PagePanelLoader");

    private PanelType PageType;
    public void Build()
    {
        ProjectSetup();
        //CreateTemplateTypes();
        //GenerateContent();
        //AddToTree();
    }

    public void CleanAll()
    {
        cleanProject.CleanAll();
    }

    public void ProjectSetup()
    {
        cleanProject.CleanAll();
        folderSetup.GenerateFolderLayout();
        AddBaseLayoutToMainWindow();
    }

    /// <summary>
    /// Creating the Types (both template and object)
    /// The Template types are the optix visual elements, instances can be made from the type
    /// Object type gets its properties that
    /// When both the object and template type are created, then an alias node can be attached
    /// </summary>
    public void CreateTemplateTypes()
    {
        header = new Header("HeaderItem", UIFolders.LayoutTemplatesGeneric, ModelFolders.ObjectsHeader);
        header.CreateHeaderItemTemplateType();
        header.CreateHeaderItemObjectType();

        sidebar = new Sidebar("SidebarItem", UIFolders.LayoutTemplatesGeneric, ModelFolders.ObjectsNavigation);
        sidebar.CreateSidebarItemTemplateType();
        sidebar.CreateSidebarItemObjectType();

        PageType = layouts.GenerateEmptyPageType();
        FolderEnumLookup(UIFolders.LayoutTemplatesGeneric).Add(PageType);

        alarms = new Alarms("Alarm", UIFolders.LayoutTemplatesGenericAlarm, ModelFolders.ObjectsAlarm);
        alarms.CreateAlarmTemplateType();
        alarms.CreateAlarmObjectType();

        performanceItem = new PerformanceItem("PerformanceItem", UIFolders.LayoutTemplatesHome, ModelFolders.ObjectsHomePerformance);
        performanceItem.CreatePerformanceItemTemplateType();
        performanceItem.CreatePerformanceItemObjectType();

        localPageNavigation = new LocalPageNavigation("LocalNavigationOption", UIFolders.LayoutTemplatesGeneric, ModelFolders.ObjectsLocalPageNavigation);
        localPageNavigation.CreateLocalNavigationOptionButtonTemplateType();
        localPageNavigation.CreateLocalNavigationOptionButtonObjectType();
        /////////////////////////////////////////Need to put a Home class////////////////////////////////////
        ///
    }

    public void GenerateContent()
    {
        alarms.MakeAlarmObjectInstance("Short", StationNumberEnum.Station10, AlarmEnum.Error, AlarmMessageType.Short);
        alarms.MakeAlarmObjectInstance("Medium", StationNumberEnum.Station6, AlarmEnum.Error, AlarmMessageType.Medium);
        alarms.MakeAlarmObjectInstance("Long", StationNumberEnum.Station7, AlarmEnum.Warning, AlarmMessageType.Long);
        alarms.CreateTemplateInstanceContainer();
        var alarmLocationFromContainerToAddInstancesTo = alarms.TemplateInstanceContainer.Find<ColumnLayout>("PanelContentVerticalLayout");
        GenerateTemplateInstancesFromObjectInstances(alarmLocationFromContainerToAddInstancesTo, alarms.TemplateType, alarms.ObjectInstancesFolder, alarms.ObjectAliasName);

        header.MakeHeaderItemObjectInstance("CamAngle", CamAngleIconPath);
        header.MakeHeaderItemObjectInstance("User", UserIconPath);
        header.MakeHeaderItemObjectInstance("Status", StatusIconPath);
        header.CreateTemplateInstanceContainer();
        var headerLocationFromContainerToAddInstancesTo = header.TemplateInstanceContainer.Find<RowLayout>("Right");
        GenerateTemplateInstancesFromObjectInstances(headerLocationFromContainerToAddInstancesTo, header.TemplateType, header.ObjectInstancesFolder, header.ObjectAliasName);

        sidebar.MakeSidebarItemObjectInstance("Home", NavigationEnum.Home);
        sidebar.MakeSidebarItemObjectInstance("Station", NavigationEnum.Station);
        sidebar.CreateTemplateInstanceContainer();
        var sidebarLocationFromContainerToAddInstancesTo = sidebar.TemplateInstanceContainer.Find<ColumnLayout>("Top");
        GenerateTemplateInstancesFromObjectInstances(sidebarLocationFromContainerToAddInstancesTo, sidebar.TemplateType, sidebar.ObjectInstancesFolder, sidebar.ObjectAliasName);
        for (int i = 1; i < 7; i++)
        {
            string name = "PlaceholderButton" + i.ToString();
            var instanceOfTypeOnly = InformationModel.MakeObject(name, sidebar.TemplateType.NodeId);
            sidebarLocationFromContainerToAddInstancesTo.Add(instanceOfTypeOnly);
        }

        performanceItem.MakePerformanceItemObjectInstance("HighestScrap", "Highest Scrap", "10");
        performanceItem.MakePerformanceItemObjectInstance("LowestEfficiency", "Lowest Efficiency", "10");
        performanceItem.MakePerformanceItemObjectInstance("Performance", "Performance", "80%");
        performanceItem.MakePerformanceItemObjectInstance("Quality", "Quality", "75%");
        performanceItem.CreateTemplateInstanceContainer();
        ColumnLayout performanceItemLocationFromContainerToAddInstancesTo = performanceItem.TemplateInstanceContainer.Find<ColumnLayout>("PanelContentVerticalLayout");
        GenerateTemplateInstancesFromObjectInstances(performanceItemLocationFromContainerToAddInstancesTo, performanceItem.TemplateType, performanceItem.ObjectInstancesFolder, performanceItem.ObjectAliasName);

        localPageNavigation.MakeLocalNavigationOptionButtonObjectInstance("Line", "Line");
        localPageNavigation.MakeLocalNavigationOptionButtonObjectInstance("Cell", "Cell");
        localPageNavigation.MakeLocalNavigationOptionButtonObjectInstance("Module", "Module");
        //localPageNavigation.CreateTemplateInstanceContainer();
        RowLayout localPageNavigationLocationFromContainerToAddInstancesTo = localPageNavigation.TemplateInstanceContainer.Find<RowLayout>("LocalPageNavigationOptionsHorizontalLayout");
        GenerateTemplateInstancesFromObjectInstances(localPageNavigationLocationFromContainerToAddInstancesTo, localPageNavigation.TemplateType, localPageNavigation.ObjectInstancesFolder, localPageNavigation.ObjectAliasName);
    }

    public void AddToTree()
    {
        PagePanelLoader.Panel = PageType.NodeId;
        HeaderPanelLoader.Panel = header.TemplateInstanceContainer.NodeId;
        SidebarPanelLoader.Panel = sidebar.TemplateInstanceContainer.NodeId;

        PanelLoader rightDashboardPanelLoader = GetRightDashboardPanelLoader();
        rightDashboardPanelLoader.Panel = alarms.TemplateInstanceContainer.NodeId;

        PanelLoader leftDashboardPanelLoader = GetLeftDashboardPanelLoader();
        leftDashboardPanelLoader.Panel = performanceItem.TemplateInstanceContainer.NodeId;

        SetMainContentPanelLoaderPanel(localPageNavigation.TemplateInstanceContainer);
    }

    public void AddBaseLayoutToMainWindow()
    {
        Panel baseLayout = MakeDefaultPanel("Base");
        baseLayout.Height = 768;
        baseLayout.Width = 1024;
        ColumnLayout baseVerticalLayout = MakeDefaultVerticalLayout("BaseVerticalLayout");
        RowLayout baseHorizontalLayout = MakeDefaultHorizontalLayout("BaseHorizontalLayout");

        HeaderPanelLoader.Height = HeaderHeight;
        HeaderPanelLoader.VerticalAlignment = HeaderVerticalAlignment;
        SidebarPanelLoader.Width = SidebarWidth;
        SidebarPanelLoader.HorizontalAlignment = SidebarHorizontalAlignment;

        baseLayout.Add(BaseBackground);
        baseLayout.Add(baseVerticalLayout);
        baseVerticalLayout.Add(HeaderPanelLoader);
        baseVerticalLayout.Add(baseHorizontalLayout);
        baseHorizontalLayout.Add(SidebarPanelLoader);
        baseHorizontalLayout.Add(PageBackground);
        PageBackground.Add(PagePanelLoader);

        AddToMainWindow(baseLayout);
    }
    public void MakePageViewModels()
    {
    }
}
