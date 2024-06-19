using FTOptix.HMIProject;
using FTOptix.UI;
using MOAB.Optix.Core.Builder.Flyouts;
using MOAB.Optix.Core.Builder.Helpers;
using UAManagedCore;
using static MOAB.Optix.Core.Builder.Helpers.Enumerations;
using static MOAB.Optix.Core.Builder.Helpers.HmiStyledElements;
using static MOAB.Optix.Core.Builder.Helpers.HmiStyles;
using static MOAB.Optix.Core.Builder.Helpers.Icons;
using static MOAB.Optix.Core.Builder.Helpers.TreeShortcuts;

namespace MOAB.Optix.Core.Builder.Templates;

public class Header : TemplateTypeBaseClass
{
    private Layouts layouts = new Layouts();
    private string dropdownButtonName;
    private string dropdownButtonImagePathVariable;
    private string dropdownButtonPanelVariable;

    public Header(string nameOfType, UIFolders templateFolder, ModelFolders objectFolder)
    {
        SetPropertiesFromBase(nameOfType, templateFolder, objectFolder);

        dropdownButtonName = "HeaderDropdownButton";
        dropdownButtonImagePathVariable = CreateVariableNameString(dropdownButtonName, "ImagePath");
        //dropdownButtonPanelVariable = CreateVariableNameString(dropdownButtonName, "Panel");
    }
    public HeaderFlyouts headerFlyouts;

    public void CreateHeaderItemTemplateType()
    {
        TemplateType.HorizontalAlignment = HorizontalRight;

        DropDownButton headerDropdownButton = MakeDefaultDropdownButton(dropdownButtonName);
        headerDropdownButton.ImageHeight = StandardIconHeight;
        headerDropdownButton.ImagePath = PlaceholderIconPath;

        PanelType dropdownPanel = CreateDropdownButtonPanel();
        headerDropdownButton.Panel = dropdownPanel.NodeId;

        TemplateType.Add(headerDropdownButton);
    }

    public void CreateHeaderItemObjectType()
    {
        IUAVariable headerItemIcon = InformationModel.MakeVariable(dropdownButtonImagePathVariable, FTOptix.Core.DataTypes.ResourceUri);
        //IUAVariable headerItemFlyout = InformationModel.MakeVariable(dropdownButtonPanelVariable, NodePointer);

        ObjectType.Add(headerItemIcon);
        //ObjectType.Add(headerItemFlyout);
    }

    public void MakeHeaderItemObjectInstance(string instanceID, string icon)
    {
        IUAObject objectInstance = CreateObjectInstance(instanceID);
        objectInstance.FindVariable(dropdownButtonImagePathVariable).Value = icon;
        objectInstance.FindVariable(dropdownButtonImagePathVariable).Value = icon;
    }

    public override void CreateTemplateInstanceContainer()
    {
        PanelType headerPanelType = MakeDefaultPanelType("HeaderPanelType");
        headerPanelType.VerticalAlignment = VerticalTop;
        headerPanelType.Height = 50;
        RowLayout headerHorizontalLayout = layouts.CreateLeftRightLayout("HeaderHorizontalLayout");

        RowLayout left = (RowLayout)headerHorizontalLayout.Children[0];

        CreateHeaderLeft(left);

        headerPanelType.Add(headerHorizontalLayout);

        TemplateInstanceContainer = headerPanelType;
        FolderEnumLookup(TemplateInstancesFolder).Add(TemplateInstanceContainer);
    }

    public void CreateHeaderLeft(RowLayout left)
    {
        ColumnLayout dateTime = layouts.CreateTopBottomLayout("DateTime", "Time", "Date");
        dateTime.HorizontalAlignment = HorizontalAlignment.Left;
        ColumnLayout time = (ColumnLayout)dateTime.Children[0];
        ColumnLayout date = (ColumnLayout)dateTime.Children[1];
        Label timeLabel = MakeDefaultLabel("TimeLabel", "11:30");
        Label dateLabel = MakeDefaultLabel("DateLabel", "02/21/2024");
        time.Add(timeLabel);
        date.Add(dateLabel);
        MikronAutomationLogo.HorizontalAlignment = HorizontalAlignment.Left;
        MikronAutomationLogo.VerticalAlignment = VerticalAlignment.Center;

        left.Add(MikronAutomationLogo);
        left.Add(dateTime);
    }

    public PanelType CreateDropdownButtonPanel()
    {
        PanelType dropdownPanel = MakeDefaultDropdownPanelType("HeaderItemDropdownPanel");
        FolderEnumLookup(TemplateFolder).Add(dropdownPanel);
        return dropdownPanel;
    }
}
