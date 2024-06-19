using FTOptix.UI;
using UAManagedCore;
using static MOAB.Optix.Core.Builder.Helpers.HmiStyledElements;
using static MOAB.Optix.Core.Builder.Helpers.HmiStyles;
using static MOAB.Optix.Core.Builder.Helpers.TreeShortcuts;


namespace MOAB.Optix.Core.Builder.Helpers;

public class Layouts
{
    public Layouts()
    {
    }

    public PanelType GenerateEmptyPageType()
    {
        PanelType page = MakeDefaultPanelType("Page");
        ColumnLayout pageVerticalLayout = MakeDefaultVerticalLayout("PageVerticalLayout");
        RowLayout dashboard = GenerateDashboard("Dashboard");
        PanelLoader mainContent = MakeDefaultPanelLoaderSection("MainContentPanelLoader");

        page.Add(pageVerticalLayout);
        pageVerticalLayout.Add(dashboard);
        pageVerticalLayout.Add(mainContent);

        return page;
    }

    public RowLayout GenerateDashboard(string browseName)
    {
        RowLayout dashboard = MakeDefaultHorizontalLayout(browseName);
        dashboard.VerticalAlignment = VerticalTop;
        dashboard.Height = 100;

        PanelLoader Left = MakeDefaultPanelLoaderSection("DashboardLeftPanelLoader");
        Left.Width = 300;
        PanelLoader Right = MakeDefaultPanelLoaderSection("DashboardRightPanelLoader");

        dashboard.Add(Left);
        dashboard.Add(Right);
        return dashboard;
    }

    public ColumnLayout CreateTopBottomLayout(string browseName, string topName = "Top", string bottomName = "Bottom")
    {
        ColumnLayout verticalLayoutTopBottom = MakeDefaultVerticalLayout(browseName);

        ColumnLayout topVerticalLayout = MakeDefaultVerticalLayout(topName);
        ColumnLayout bottomVerticalLayout = MakeDefaultVerticalLayout(bottomName);

        topVerticalLayout.ContentAlignment = ContentVerticalAlignment.Top;
        bottomVerticalLayout.ContentAlignment = ContentVerticalAlignment.Bottom;
        topVerticalLayout.HorizontalAlignment = HorizontalAlignment.Center;
        bottomVerticalLayout.HorizontalAlignment = (HorizontalAlignment)VerticalAlignment.Center;

        verticalLayoutTopBottom.Add(topVerticalLayout);
        verticalLayoutTopBottom.Add(bottomVerticalLayout);

        return verticalLayoutTopBottom;
    }

    public RowLayout CreateLeftRightLayout(string browseName, string leftName = "Left", string rightName = "Right")
    {
        RowLayout horizontalLayoutLeftRight = MakeDefaultHorizontalLayout(browseName);

        RowLayout leftHorizontalLayout = MakeDefaultHorizontalLayout(leftName);
        RowLayout rightHorizontalLayout = MakeDefaultHorizontalLayout(rightName);

        leftHorizontalLayout.ContentAlignment = ContentHorizontalAlignment.Left;
        rightHorizontalLayout.ContentAlignment = ContentHorizontalAlignment.Right;
        leftHorizontalLayout.VerticalAlignment = VerticalAlignment.Center;
        rightHorizontalLayout.VerticalAlignment = VerticalAlignment.Center;
        leftHorizontalLayout.HorizontalAlignment = HorizontalAlignment.Stretch;
        rightHorizontalLayout.HorizontalAlignment = HorizontalAlignment.Stretch;

        horizontalLayoutLeftRight.Add(leftHorizontalLayout);
        horizontalLayoutLeftRight.Add(rightHorizontalLayout);

        return horizontalLayoutLeftRight;
    }

    public RowLayout CreateLeftRightLayout<T1, T2>(T1 leftElement, T2 rightElement, string browseName)
    {
        RowLayout horizontalLayoutLeftRight = MakeDefaultHorizontalLayout(browseName);

        RowLayout leftHorizontalLayout = MakeDefaultHorizontalLayout();
        RowLayout rightHorizontalLayout = MakeDefaultHorizontalLayout();

        leftHorizontalLayout.ContentAlignment = ContentHorizontalAlignment.Left;
        rightHorizontalLayout.ContentAlignment = ContentHorizontalAlignment.Right;
        leftHorizontalLayout.VerticalAlignment = VerticalAlignment.Center;
        rightHorizontalLayout.VerticalAlignment = VerticalAlignment.Center;
        leftHorizontalLayout.HorizontalAlignment = HorizontalAlignment.Stretch;
        rightHorizontalLayout.HorizontalAlignment = HorizontalAlignment.Stretch;

        leftHorizontalLayout.Add((IUANode)leftElement);
        rightHorizontalLayout.Add((IUANode)rightElement);
        horizontalLayoutLeftRight.Add(leftHorizontalLayout);
        horizontalLayoutLeftRight.Add(rightHorizontalLayout);

        return horizontalLayoutLeftRight;
    }

    //public ColumnLayout CreateTopBottomLayout<T1, T2>(T1 topElement, T2 bottomElement, string browseName)
    //{
    //    ColumnLayout verticalLayoutTopBottom = MakeDefaultVerticalLayout(browseName);

    //    Panel topPanel = MakeDefaultPanel("Top");
    //    Panel bottomPanel = MakeDefaultPanel("Bottom");

    //    Panel topElementContainer = MakeDefaultPanel("TopContainer");
    //    Panel bottomElementContainer = MakeDefaultPanel("BottomContainer");

    //    topElementContainer.VerticalAlignment = VerticalTop;
    //    bottomElementContainer.VerticalAlignment = VerticalBottom;

    //    topElementContainer.Add((IUANode)topElement);
    //    bottomElementContainer.Add((IUANode)bottomElement);
    //    topPanel.Add(topElementContainer);
    //    bottomPanel.Add(bottomElementContainer);

    //    verticalLayoutTopBottom.Add(topPanel);
    //    verticalLayoutTopBottom.Add(bottomPanel);

    //    return verticalLayoutTopBottom;
    //}
    public ColumnLayout CreateTopBottomLayout<T1, T2>(T1 topElement, T2 bottomElement, string browseName)
    {
        ColumnLayout verticalLayoutTopBottom = MakeDefaultVerticalLayout(browseName);

        ColumnLayout topVerticalLayout = MakeDefaultVerticalLayout("TopVerticalLayout");
        ColumnLayout bottomVerticalLayout = MakeDefaultVerticalLayout("BottomVerticalLayout");

        topVerticalLayout.ContentAlignment = ContentVerticalAlignment.Top;
        bottomVerticalLayout.ContentAlignment = ContentVerticalAlignment.Bottom;
        topVerticalLayout.HorizontalAlignment = HorizontalAlignment.Stretch;
        bottomVerticalLayout.HorizontalAlignment = (HorizontalAlignment)VerticalAlignment.Stretch;

        topVerticalLayout.Add((IUANode)topElement);
        bottomVerticalLayout.Add((IUANode)bottomElement);

        verticalLayoutTopBottom.Add(topVerticalLayout);
        verticalLayoutTopBottom.Add(bottomVerticalLayout);

        return verticalLayoutTopBottom;
    }

    public RowLayout CreateKeyValueLeftAlignedColumnLayout(string browseName, string keyName, string valueName)
    {
        RowLayout horizontalLayout = MakeDefaultHorizontalLayout(browseName);
        Panel keyContainerPanel = MakeDefaultPanel("KeyContainerPanel");
        Panel valueContainerPanel = MakeDefaultPanel("ValueContainerPanel");
        Label keyLabel = MakeDefaultLabel(keyName);
        Label valueLabel = MakeDefaultLabel(valueName);

        horizontalLayout.ContentAlignment = ContentHorizontalAlignment.Left;
        keyLabel.TextHorizontalAlignment = TextHorizontalAlignment.Left;
        valueLabel.TextHorizontalAlignment = TextHorizontalAlignment.Left;

        keyContainerPanel.Add(keyLabel);
        valueContainerPanel.Add(valueLabel);
        horizontalLayout.Add(keyContainerPanel);
        horizontalLayout.Add(valueContainerPanel);

        return horizontalLayout;
    }

    public RowLayout CreateKeyValueLeftAlignedColumnLayout(string browseName, string keyName, string valueName, string key, string value)
    {
        RowLayout horizontalLayout = MakeDefaultHorizontalLayout(browseName);
        Panel keyContainerPanel = MakeDefaultPanel("KeyContainerPanel");
        Panel valueContainerPanel = MakeDefaultPanel("ValueContainerPanel");
        Label keyLabel = MakeDefaultLabel(keyName);
        Label valueLabel = MakeDefaultLabel(valueName);

        horizontalLayout.ContentAlignment = ContentHorizontalAlignment.Left;
        keyLabel.TextHorizontalAlignment = TextHorizontalAlignment.Left;
        valueLabel.TextHorizontalAlignment = TextHorizontalAlignment.Left;
        keyLabel.Text = key;
        valueLabel.Text = value;

        keyContainerPanel.Add(keyLabel);
        valueContainerPanel.Add(valueLabel);
        horizontalLayout.Add(keyContainerPanel);
        horizontalLayout.Add(valueContainerPanel);

        return horizontalLayout;
    }

    public RowLayout CreateKeyValueLeftAlignedColumnLayout<T1, T2>(T1 keyElement, T2 valueElement, string browseName)
    {
        RowLayout horizontalLayout = MakeDefaultHorizontalLayout(browseName);
        Panel keyContainerPanel = MakeDefaultPanel("KeyContainerPanel");
        Panel valueContainerPanel = MakeDefaultPanel("ValueContainerPanel");

        horizontalLayout.ContentAlignment = ContentHorizontalAlignment.Left;

        keyContainerPanel.Add((IUANode)keyElement);
        valueContainerPanel.Add((IUANode)valueElement);
        horizontalLayout.Add(keyContainerPanel);
        horizontalLayout.Add(valueContainerPanel);

        return horizontalLayout;
    }

    public Panel CreatePanelWithUpperRightButtonLayout(string browseName, string buttonIcon)
    {
        Panel containerPanel = MakeDefaultPanel("ContainerPanel");

        Button upperRightHandButton = MakeDefaultButton("UpperRightHandButton");
        string buttonIconPath = GetRelativeImagePath(buttonIcon);
        upperRightHandButton.ImagePath = buttonIconPath;
        upperRightHandButton.HorizontalAlignment = HorizontalAlignment.Right;
        upperRightHandButton.VerticalAlignment = VerticalAlignment.Top;

        ColumnLayout contentVerticalLayout = MakeDefaultVerticalLayout("PanelContentVerticalLayout");

        containerPanel.Add(upperRightHandButton);
        containerPanel.Add(contentVerticalLayout);

        return containerPanel;
    }

    public PanelType CreatePanelWithUpperRightButtonLayoutType(string browseName, string buttonIcon)
    {
        PanelType containerPanel = MakeDefaultPanelType(browseName);

        Button upperRightHandButton = MakeDefaultButton("UpperRightHandButton");
        string buttonIconPath = GetRelativeImagePath(buttonIcon);
        upperRightHandButton.ImagePath = buttonIconPath;
        upperRightHandButton.HorizontalAlignment = HorizontalAlignment.Right;
        upperRightHandButton.VerticalAlignment = VerticalAlignment.Top;

        ColumnLayout contentVerticalLayout = MakeDefaultVerticalLayout("PanelContentVerticalLayout");

        containerPanel.Add(upperRightHandButton);
        containerPanel.Add(contentVerticalLayout);

        return containerPanel;
    }
}
