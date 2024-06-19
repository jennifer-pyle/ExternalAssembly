using FTOptix.HMIProject;
using FTOptix.UI;
using MOAB.Optix.Core.Builder.Helpers;
using UAManagedCore;
using static MOAB.Optix.Core.Builder.Helpers.Enumerations;
using static MOAB.Optix.Core.Builder.Helpers.HmiStyledElements;
using static MOAB.Optix.Core.Builder.Helpers.HmiStyles;
using static MOAB.Optix.Core.Builder.Helpers.Icons;
using static MOAB.Optix.Core.Builder.Helpers.TreeShortcuts;

namespace MOAB.Optix.Core.Builder.Templates;

public class Sidebar : TemplateTypeBaseClass
{
    private Layouts layouts = new Layouts();

    public Sidebar(string nameOfType, UIFolders templateFolder, ModelFolders objectFolder)
    {
        SetPropertiesFromBase(nameOfType, templateFolder, objectFolder);

        SidebarButtonImagePathVariable = CreateVariableNameString(SidebarButtonName, "ImagePath");
    }

    public string SidebarButtonName = "SidebarButton";
    public string SidebarButtonImagePathVariable;

    public void CreateSidebarItemTemplateType()
    {
        TemplateType.Height = StandardButtonHeight;
        TemplateType.Width = StandardButtonWidth;
        TemplateType.VerticalAlignment = VerticalTop;

        Button sidebarButton = MakeDefaultButton(SidebarButtonName);
        sidebarButton.ImageHeight = StandardIconHeight;
        sidebarButton.ImagePath = PlaceholderIconPath;

        TemplateType.Add(sidebarButton);
    }

    public void CreateSidebarItemObjectType()
    {
        IUAVariable sidebarIcon = InformationModel.MakeVariable(SidebarButtonImagePathVariable, FTOptix.Core.DataTypes.ResourceUri);

        ObjectType.Add(sidebarIcon);
    }

    public void MakeSidebarItemObjectInstance(string instanceID, NavigationEnum pageType)
    {
        IUAObject objectInstance = CreateObjectInstance(instanceID);
        objectInstance.FindVariable(SidebarButtonImagePathVariable).Value = GetPageIcon(pageType);
    }

    public override void CreateTemplateInstanceContainer()
    {
        PanelType sidebarPanelType = MakeDefaultPanelType("SidebarPanelType");
        sidebarPanelType.Width = 50;
        sidebarPanelType.HorizontalAlignment = HorizontalLeft;
        ColumnLayout sidebarVerticalLayout = layouts.CreateTopBottomLayout("SidebarVerticalLayout");

        ColumnLayout top = (ColumnLayout)sidebarVerticalLayout.Children[0];
        ColumnLayout bottom = (ColumnLayout)sidebarVerticalLayout.Children[1];

        sidebarPanelType.Add(sidebarVerticalLayout);
        TemplateInstanceContainer = sidebarPanelType;
        FolderEnumLookup(TemplateInstancesFolder).Add(TemplateInstanceContainer);
    }

    private string GetPageIcon(NavigationEnum pageType)
    {
        switch (pageType)
        {
            case NavigationEnum.Home:
                return HomeIconPath;

            case NavigationEnum.Station:
                return StationIconPath;

            case NavigationEnum.None:
                return PlaceholderIconPath;

            default:
                return PlaceholderIconPath;
        }
    }
}