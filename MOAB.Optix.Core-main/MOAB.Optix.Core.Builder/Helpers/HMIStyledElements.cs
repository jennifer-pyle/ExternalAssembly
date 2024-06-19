using FTOptix.HMIProject;
using FTOptix.UI;
using UAManagedCore;
using static MOAB.Optix.Core.Builder.Helpers.HmiStyles;
using static MOAB.Optix.Core.Builder.Helpers.HmiColors;
using static MOAB.Optix.Core.Builder.Helpers.TreeShortcuts;
using static MOAB.Optix.Core.Builder.Helpers.Icons;
using MOAB.Optix.Core.Builder.Flyouts;

namespace MOAB.Optix.Core.Builder.Helpers;

/// <summary>
/// Default elements like Rectangle, Panel, etc. So they automatically have desired style
/// </summary>
public class HmiStyledElements
{
    #region Basic elements without children

    public static Button MakeDefaultButton(string browseName)
    {
        Button button = InformationModel.Make<Button>(browseName);
        button.Width = -1;
        button.Height = -1;
        button.HorizontalAlignment = HorizontalStretch;
        button.VerticalAlignment = VerticalStretch;
        button.BackgroundColor = SecondaryColor;
        button.TextColor = White;
        button.FontSize = ButtonFontSize;

        return button;
    }

    public static Rectangle MakeDefaultRectangle(string browseName)
    {
        Rectangle rectangle = InformationModel.Make<Rectangle>(browseName);
        rectangle.Width = -1;
        rectangle.Height = -1;
        rectangle.HorizontalAlignment = HorizontalStretch;
        rectangle.VerticalAlignment = VerticalStretch;
        rectangle.FillColor = PrimaryColor;
        rectangle.BorderColor = PrimaryBorder;
        rectangle.BorderThickness = 3;
        rectangle.CornerRadius = 10;

        return rectangle;
    }

    public static Ellipse MakeDefaultEllipse(string browseName)
    {
        Ellipse ellipse = InformationModel.Make<Ellipse>(browseName);
        ellipse.BorderColor = White;
        ellipse.FillColor = Transparent;
        ellipse.BorderThickness = 3;
        ellipse.Height = 45;
        ellipse.Width = 45;

        return ellipse;
    }

    public static Label MakeDefaultLabel(string browseName, string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.")
    {
        Label label = InformationModel.Make<Label>(browseName);
        label.Text = text;
        label.TextColor = White;
        label.HorizontalAlignment = HorizontalStretch;
        label.VerticalAlignment = VerticalStretch;
        label.TextHorizontalAlignment = TextHorizontalAlignment.Left;
        label.TextVerticalAlignment = TextVerticalAlignment.Bottom;

        return label;
    }

    //TODO need way to handle null folder
    public static Image MakeDefaultImage(string browseName, string imageName = "placeholder.svg")
    {
        Image image = InformationModel.Make<Image>(browseName);
        string imageResourceUri = GetRelativeImagePath(imageName);
        image.Path = imageResourceUri;
        image.FillMode = FillMode.Stretch;
        image.HorizontalAlignment = HorizontalStretch;
        image.VerticalAlignment = VerticalAlignment.Stretch;

        return image;
    }

    public static Image MakeDefaultImageIconSize(string browseName, string imageName = "placeholder.svg")
    {
        Image image = InformationModel.Make<Image>(browseName);
        string imageResourceUri = GetRelativeImagePath(imageName);
        image.Path = imageResourceUri;
        image.FillMode = FillMode.Stretch;
        image.HorizontalAlignment = HorizontalCenter;
        image.VerticalAlignment = VerticalCenter;
        image.Height = StandardIconHeight;
        image.Width = StandardIconWidth;

        return image;
    }

    public static Panel MakeDefaultPanel(string browseName)
    {
        Panel panel = InformationModel.Make<Panel>(browseName);
        panel.Width = -1;
        panel.Height = -1;
        panel.HorizontalAlignment = HorizontalStretch;
        panel.VerticalAlignment = VerticalStretch;

        return panel;
    }

    public static PanelLoader MakeDefaultPanelLoader(string browseName)
    {
        PanelLoader panelLoader = InformationModel.Make<PanelLoader>(browseName);
        panelLoader.Width = -1;
        panelLoader.Height = -1;
        panelLoader.HorizontalAlignment = HorizontalStretch;
        panelLoader.VerticalAlignment = VerticalStretch;

        return panelLoader;
    }

    public static ColumnLayout MakeDefaultVerticalLayout(string browseName = "VerticalLayout")
    {
        ColumnLayout column = InformationModel.Make<ColumnLayout>(browseName);
        column.Width = -1;
        column.Height = -1;
        column.HorizontalAlignment = HorizontalStretch;
        column.VerticalAlignment = VerticalStretch;

        return column;
    }

    public static RowLayout MakeDefaultHorizontalLayout(string browseName = "HorizontalLayout")
    {
        RowLayout row = InformationModel.Make<RowLayout>(browseName);
        row.Width = -1;
        row.Height = -1;
        row.HorizontalAlignment = HorizontalStretch;
        row.VerticalAlignment = VerticalStretch;

        return row;
    }

    #endregion

    #region Basic Elements with children

    public static Panel MakeDefaultPanelSection(string browseName)
    {
        Panel panel = MakeDefaultPanel(browseName);
        Rectangle panelBackground = MakeDefaultRectangle("Background");

        panel.Add(panelBackground);

        return panel;
    }

    public static PanelLoader MakeDefaultPanelLoaderSection(string browseName)
    {
        PanelLoader panelLoader = MakeDefaultPanelLoader(browseName);
        Rectangle panelBackground = MakeDefaultRectangle("Background");

        panelLoader.Add(panelBackground);

        return panelLoader;
    }

    public static PanelLoader MakeDefaultPanelLoaderLocalPageNavigationSection(string browseName)
    {
        PanelLoader panelLoader = MakeDefaultPanelLoader(browseName);
        Rectangle panelBackground = MakeDefaultRectangle("Background");
        panelBackground.BorderColor = SecondaryColor;
        panelBackground.FillColor = Transparent;

        panelLoader.Add(panelBackground);

        return panelLoader;
    }

    public static DropDownButton MakeDefaultDropdownButton(string browseName, string imageName = null, bool isStandardSize = false)
    {
        DropDownButton dropdownButton = InformationModel.Make<DropDownButton>(browseName);
        dropdownButton.Width = -1;
        dropdownButton.Height = -1;
        dropdownButton.HorizontalAlignment = HorizontalCenter;
        dropdownButton.VerticalAlignment = VerticalCenter;
        dropdownButton.BackgroundColor = SecondaryColor;
        dropdownButton.TextColor = White;
        dropdownButton.FontSize = ButtonFontSize;

        //TODO - change to not make it a double negative
        if (!string.IsNullOrEmpty(imageName))
        {
            string iconPath = GetRelativeImagePath(imageName);
            dropdownButton.ImagePath = iconPath;

            if (isStandardSize)
            {
                dropdownButton.Width = ButtonWidth;
                dropdownButton.ImageWidth = ButtonWidth;
            }
        }
        return dropdownButton;
    }

    public static Rectangle MakeDefaultSecondaryBackground(string browseName = "SecondaryBackground")
    {
        Rectangle rectangle = MakeDefaultRectangle(browseName);
        rectangle.FillColor = PrimaryColor;
        rectangle.BorderColor = PrimaryBorder;
        rectangle.BorderThickness = 3;
        rectangle.CornerRadius = 10;

        return rectangle;
    }

    public static Rectangle MakeDefaultPlaceholder(string browseName, string text = "Placeholder")
    {
        Rectangle placeholder = MakeDefaultRectangle(browseName);
        placeholder.TopMargin = 10;
        placeholder.BottomMargin = 10;
        placeholder.LeftMargin = 10;
        placeholder.RightMargin = 10;
        placeholder.FillColor = PrimaryColor;
        placeholder.BorderColor = PrimaryBorder;
        placeholder.BorderThickness = 3;
        placeholder.CornerRadius = 10;
        Label label = InformationModel.Make<Label>("Label");
        label.HorizontalAlignment = HorizontalCenter;
        label.VerticalAlignment = VerticalCenter;
        label.Text = text;
        label.FontSize = 25;
        placeholder.Add(label);

        return placeholder;
    }

    #endregion

    #region Default Types

    public static PanelType MakeDefaultPanelType(string browseName)
    {
        PanelType panel = InformationModel.Make<PanelType>(browseName);
        panel.Width = -1;
        panel.Height = -1;
        panel.HorizontalAlignment = HorizontalStretch;
        panel.VerticalAlignment = VerticalStretch;

        return panel;
    }

    public static ButtonType MakeDefaultButtonType(string browseName)
    {
        ButtonType buttonType = InformationModel.Make<ButtonType>(browseName);
        buttonType.Width = -1;
        buttonType.Height = -1;
        buttonType.HorizontalAlignment = HorizontalStretch;
        buttonType.VerticalAlignment = VerticalStretch;
        buttonType.BackgroundColor = SecondaryColor;
        buttonType.TextColor = White;
        buttonType.FontSize = ButtonFontSize;

        return buttonType;
    }

    public static ColumnLayoutType MakeDefaultVerticalLayoutType(string browseName)
    {
        ColumnLayoutType columnType = InformationModel.Make<ColumnLayoutType>(browseName);
        columnType.Width = -1;
        columnType.Height = -1;
        columnType.HorizontalAlignment = HorizontalStretch;
        columnType.VerticalAlignment = VerticalStretch;

        return columnType;
    }

    public static RowLayoutType MakeDefaultHorizontalLayoutType(string browseName)
    {
        RowLayoutType rowType = InformationModel.Make<RowLayoutType>(browseName);
        rowType.Width = -1;
        rowType.Height = -1;
        rowType.HorizontalAlignment = HorizontalStretch;
        rowType.VerticalAlignment = VerticalStretch;

        return rowType;
    }

    public static ImageType MakeDefaultImageType(string browseName, string imageName = "placeholder.svg")
    {
        ImageType imageType = InformationModel.Make<ImageType>(browseName);
        string imageResourceUri = GetRelativeImagePath(imageName);
        imageType.Path = imageResourceUri;
        imageType.FillMode = FillMode.Stretch;
        imageType.HorizontalAlignment = HorizontalCenter;
        imageType.VerticalAlignment = VerticalCenter;

        return imageType;
    }

    public static DialogType MakeDefaultDialogBoxType(string browseName)
    {
        DialogType dialogType = InformationModel.Make<DialogType>(browseName);
        dialogType.Width = -1;
        dialogType.Height = -1;
        dialogType.HorizontalAlignment = HorizontalStretch;
        dialogType.VerticalAlignment = VerticalStretch;

        return dialogType;
    }

    public DialogType MakeDefaultDialogBoxType()
    {
        DialogType dialogType = MakeDefaultDialogBoxType("d");
        Rectangle backgroundBlur = MakeDefaultRectangle("BackgroundBlur");
        backgroundBlur.BorderThickness = 0;
        backgroundBlur.FillColor = Black;
        backgroundBlur.Opacity = 75F;
        // PanelLoader dialogPanelLoader = MakeDefaultPanelLoader

        return dialogType;
    }

    public static PanelType MakeDefaultDropdownPanelType(string browseName)
    {
        HeaderFlyouts headerFlyouts = new HeaderFlyouts();
        PanelType panelType = InformationModel.Make<PanelType>(browseName);
        PanelLoader panelLoader = MakeDefaultPanelLoader("FlyoutPanelLoader");

        panelType.Width = 300;
        panelType.Height = 300;
        panelType.HorizontalAlignment = HorizontalAlignment.Right;
        panelType.VerticalAlignment = VerticalAlignment.Top;
        Rectangle borderOverlay = MakeDefaultRectangle("BorderOverlay");
        panelLoader.Panel = headerFlyouts.UserPanelType.NodeId;

        panelType.Add(GradientBackground);
        panelType.Add(borderOverlay);
        panelType.Add(panelLoader);

        return panelType;
    }

    #endregion
}
