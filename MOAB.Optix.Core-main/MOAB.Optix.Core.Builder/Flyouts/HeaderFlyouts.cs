using FTOptix.UI;
using MOAB.Optix.Core.Builder.Helpers;
using UAManagedCore;
using static MOAB.Optix.Core.Builder.Helpers.Enumerations;
using static MOAB.Optix.Core.Builder.Helpers.HmiStyledElements;
using static MOAB.Optix.Core.Builder.Helpers.HmiStyles;
using static MOAB.Optix.Core.Builder.Helpers.TreeShortcuts;

namespace MOAB.Optix.Core.Builder.Flyouts;

public class HeaderFlyouts
{
    private Layouts layouts = new Layouts();

    public HeaderFlyouts()
    {
        CreateUserFlyoutType();
        CreateMachineStatusFlyoutType();
        //CreatePowerFlyoutType();
    }
    public PanelType UserPanelType;
    public PanelType BatchInfoFlyoutPanelType;
    public PanelType ModulePanelType;

    public void CreateUserFlyoutType()
    {
        UserPanelType = MakeDefaultPanelType("User");
        ColumnLayout topSection = MakeDefaultVerticalLayout("UserInfo");
        Label username = MakeDefaultLabel("Username", "Jennifer P");
        Label userLevel = MakeDefaultLabel("UserLevel", "Operator");
        Label userStats = MakeDefaultLabel("UserStats", "User Stats: 10000");
        //topSection.VerticalAlignment = VerticalTop;
        topSection.Add(username);
        topSection.Add(userLevel);
        topSection.Add(userStats);

        Button userSettingsButton = MakeDefaultButton("UserSettingsButton");
        Button logOutButton = MakeDefaultButton("LogOutButton");
        userSettingsButton.Text = "User Settings";
        logOutButton.Text = "Log Out";
        RowLayout bottomSection = layouts.CreateLeftRightLayout(userSettingsButton, logOutButton, "UserFlyoutButtons");
        bottomSection.VerticalAlignment = VerticalBottom;
        ColumnLayout userFlyoutVerticalLayout = layouts.CreateTopBottomLayout(topSection, bottomSection, "UserFlyoutLayout");

        UserPanelType.Add(userFlyoutVerticalLayout);
        FolderEnumLookup(UIFolders.PageFlyouts).Add(UserPanelType);
    }

    public void CreateMachineStatusFlyoutType()
    {
        BatchInfoFlyoutPanelType = MakeDefaultPanelType("BatchInfoFlyoutPanel");
        ColumnLayout verticalLayout = MakeDefaultVerticalLayout();
        RowLayout editBatchRow = MakeRowWithIconAndKeyValuePairs("EditBatchName", "edit.svg", "Batch Name", "test");
        RowLayout editVariantRow = MakeRowWithIconAndKeyValuePairs("EditVariant", "edit.svg", "Variant", "DEMO1");
        RowLayout editToProduceRow = MakeRowWithIconAndKeyValuePairs("EditToProduce", "edit.svg", "To Produce", "500");

        verticalLayout.Add(editBatchRow);
        verticalLayout.Add(editVariantRow);
        verticalLayout.Add(editToProduceRow);
        BatchInfoFlyoutPanelType.Add(verticalLayout);

        FolderEnumLookup(UIFolders.PageFlyouts).Add(BatchInfoFlyoutPanelType);
    }

    public RowLayout MakeRowWithIconAndKeyValuePairs(string browseName, string imageName, string imageText, string valueText)
    {
        RowLayout editBatchNameIconWithText = MakeIconWithTextLayout(browseName + "Key", imageName, imageText);
        Label batchNameValue = MakeDefaultLabel(browseName + "Value", valueText);
        RowLayout rowHorizontalLayout = layouts.CreateKeyValueLeftAlignedColumnLayout(editBatchNameIconWithText, batchNameValue, browseName);

        return rowHorizontalLayout;
    }

    public RowLayout MakeIconWithTextLayout(string browseName, string imageName, string imageText)
    {
        RowLayout buttonWithTextLayout = MakeDefaultHorizontalLayout(browseName);
        var iconImage = MakeDefaultImage(browseName + "Image", imageName);
        Label textLabel = MakeDefaultLabel(browseName + "Label", imageText);

        iconImage.FillMode = FillMode.Fit;
        iconImage.VerticalAlignment = VerticalBottom;
        iconImage.HorizontalAlignment = HorizontalLeft;

        buttonWithTextLayout.Add(iconImage);
        buttonWithTextLayout.Add(textLabel);

        return buttonWithTextLayout;
    }

    public void CreatePowerFlyoutType()
    {
        //ModulePanelType = MakeDefaultPanelType("ModuleSVGPanel");
        //Image moduleSvg = MakeDefaultImage("ModuleSVG", "NEWStationsWithNumbers.svg");
        //ModulePanelType.Add(moduleSvg);
        //FolderEnumLookup(UIFolders.PageHomeModule).Add(ModulePanelType);
    }
}
