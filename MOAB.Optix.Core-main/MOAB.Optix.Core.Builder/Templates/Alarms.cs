using MOAB.Optix.Core.Builder.Helpers;
using FTOptix.HMIProject;
using FTOptix.UI;
using UAManagedCore;
using static MOAB.Optix.Core.Builder.Helpers.Enumerations;
using static MOAB.Optix.Core.Builder.Helpers.HmiStyledElements;
using static MOAB.Optix.Core.Builder.Helpers.HmiStyles;
using static MOAB.Optix.Core.Builder.Helpers.Icons;
using static MOAB.Optix.Core.Builder.Helpers.Placeholders;
using static MOAB.Optix.Core.Builder.Helpers.TreeShortcuts;
using OpcUa = UAManagedCore.OpcUa;
namespace MOAB.Optix.Core.Builder.Templates;

public class Alarms : TemplateTypeBaseClass
{
    private Layouts layouts = new Layouts();

    private string stationNumberIconElementName;
    private string alarmKindIconElementName;
    private string alarmMessageElementName;

    private string stationNumberIconPathVariable;
    private string alarmKindIconPathVariable;
    private string alarmMessageLabelVariable;

    /// <summary>
    /// Constructor defines and sets the dynamic elements on the template type
    /// </summary>
    /// <param name="nameOfType">Will be used to name everything. Type, Object, Instances, etc...</param>
    /// <param name="templateFolder">Found in UIFolders Enum</param>
    /// <param name="objectFolder">Found in ModelFolders Enum</param>
    public Alarms(string nameOfType, UIFolders templateFolder, ModelFolders objectFolder)
    {
        SetPropertiesFromBase(nameOfType, templateFolder, objectFolder);

        stationNumberIconElementName = "StationNumberIcon";
        alarmKindIconElementName = "AlarmKindIcon";
        alarmMessageElementName = "AlarmMessage";

        stationNumberIconPathVariable = CreateVariableNameString(stationNumberIconElementName, "Path");
        alarmKindIconPathVariable = CreateVariableNameString(alarmKindIconElementName, "Path");
        alarmMessageLabelVariable = CreateVariableNameString(alarmMessageElementName, "Text");
    }

    public void CreateAlarmTemplateType()
    {
        TemplateType.Height = AlarmItemHeight;
        RowLayout alarmHorizontalLayout = MakeDefaultHorizontalLayout("AlarmHorizontalLayout");
        Image stationNumberIcon = MakeDefaultImageIconSize(stationNumberIconElementName);
        stationNumberIcon.Height = AlarmItemHeight;
        stationNumberIcon.Width = AlarmItemWidth;
        Image alarmKindIcon = MakeDefaultImageIconSize(alarmKindIconElementName);
        alarmKindIcon.Height = AlarmItemHeight;
        alarmKindIcon.Width = AlarmItemWidth;
        Label alarmMessageLabel = MakeDefaultLabel(alarmMessageElementName);

        alarmHorizontalLayout.Add(stationNumberIcon);
        alarmHorizontalLayout.Add(alarmKindIcon);
        alarmHorizontalLayout.Add(alarmMessageLabel);
        TemplateType.Add(alarmHorizontalLayout);
    }

    public void CreateAlarmObjectType()
    {
        IUAVariable stationNumberIcon = InformationModel.MakeVariable(stationNumberIconPathVariable, FTOptix.Core.DataTypes.ResourceUri);
        IUAVariable alarmKindIcon = InformationModel.MakeVariable(alarmKindIconPathVariable, FTOptix.Core.DataTypes.ResourceUri);
        IUAVariable alarmMessage = InformationModel.MakeVariable(alarmMessageLabelVariable, OpcUa.DataTypes.String);

        ObjectType.Add(stationNumberIcon);
        ObjectType.Add(alarmKindIcon);
        ObjectType.Add(alarmMessage);
    }

    public void MakeAlarmObjectInstance(string instanceID, StationNumberEnum stationNumber, AlarmEnum alarmKind, AlarmMessageType alarmMessageType)
    {
        IUAObject objectInstance = CreateObjectInstance(instanceID);
        objectInstance.FindVariable(stationNumberIconPathVariable).Value = GetStationNumberIconPath(stationNumber);
        objectInstance.FindVariable(alarmKindIconPathVariable).Value = GetAlarmKindIconPath(alarmKind);
        objectInstance.FindVariable(alarmMessageLabelVariable).Value = GetAlarmMessage(alarmMessageType);
    }

    //Can be moved outside this class since its the container that gets added to the main screen
    public override void CreateTemplateInstanceContainer()
    {
        TemplateInstanceContainer = layouts.CreatePanelWithUpperRightButtonLayoutType("AlarmListPanelType", "Expand.svg");

        FolderEnumLookup(TemplateInstancesFolder).Add(TemplateInstanceContainer);
    }

    private string GetAlarmKindIconPath(AlarmEnum alarmKind)
    {
        switch (alarmKind)
        {
            case AlarmEnum.Ready:
                return ReadyIconPath;

            case AlarmEnum.Warning:
                return WarningIconPath;

            case AlarmEnum.Error:
                return ErrorIconPath;

            default:
                return PlaceholderIconPath;
        }
    }

    private string GetAlarmMessage(AlarmMessageType alarmMessageType)
    {
        switch (alarmMessageType)
        {
            case AlarmMessageType.Short:
                return AlarmMessageShort;

            case AlarmMessageType.Medium:
                return AlarmMessageMedium;

            case AlarmMessageType.Long:
                return AlarmMessageLong;

            default:
                return PlaceholderText;
        }
    }

    private string GetStationNumberIconPath(StationNumberEnum stationNumber)
    {
        switch (stationNumber)
        {
            case StationNumberEnum.Station1:
                return PlaceholderIconPath;

            case StationNumberEnum.Station2:
                return PlaceholderIconPath;

            case StationNumberEnum.Station3:
                return PlaceholderIconPath;

            case StationNumberEnum.Station4:
                return PlaceholderIconPath;

            case StationNumberEnum.Station5:
                return PlaceholderIconPath;

            case StationNumberEnum.Station6:
                return StationIcon6ErrorPath;

            case StationNumberEnum.Station7:
                return StationIcon7WarningPath;

            case StationNumberEnum.Station8:
                return PlaceholderIconPath;

            case StationNumberEnum.Station9:
                return PlaceholderIconPath;

            case StationNumberEnum.Station10:
                return StationIcon10ErrorPath;

            case StationNumberEnum.Station11:
                return PlaceholderIconPath;

            case StationNumberEnum.Station12:
                return PlaceholderIconPath;

            case StationNumberEnum.Station13:
                return PlaceholderIconPath;

            case StationNumberEnum.Station14:
                return PlaceholderIconPath;

            case StationNumberEnum.Station15:
                return PlaceholderIconPath;

            case StationNumberEnum.Station16:
                return PlaceholderIconPath;

            case StationNumberEnum.Station17:
                return PlaceholderIconPath;

            case StationNumberEnum.Station18:
                return PlaceholderIconPath;

            case StationNumberEnum.Station19:
                return PlaceholderIconPath;

            case StationNumberEnum.Station20:
                return PlaceholderIconPath;

            default:
                return PlaceholderIconPath;
        }
    }
}
