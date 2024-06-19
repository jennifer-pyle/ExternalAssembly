using FTOptix.UI;
using MOAB.Optix.Core.Builder.Helpers;
using static MOAB.Optix.Core.Builder.Helpers.Enumerations;
using UAManagedCore;
using static MOAB.Optix.Core.Builder.Helpers.HmiStyledElements;
using static MOAB.Optix.Core.Builder.Helpers.HmiStyles;
using static MOAB.Optix.Core.Builder.Helpers.Icons;
using static MOAB.Optix.Core.Builder.Helpers.Placeholders;
using static MOAB.Optix.Core.Builder.Helpers.TreeShortcuts;
using OpcUa = UAManagedCore.OpcUa;

namespace MOAB.Optix.Core.Builder.Templates;

public class AlarmsDifferentVersion : TemplateTypeBaseClass
{
    private Layouts layouts = new Layouts();

    private TargetElement alarmMessageElement;
    private TargetElement alarmKindIconElement;
    private TargetElement stationNumberIconElement;

    /// <summary>
    /// The dynamic variables and elements started getting confusing in my other approah. Elements/variables set within their own method
    /// Uses base class
    /// </summary>
    /// <param name="nameOfType"></param>
    /// <param name="templateFolder">Found in UIFolders Enum</param>
    /// <param name="objectFolder">Found in ModelFolders Enum</param>
    public void _AlarmsDifferentVersion(string nameOfType, UIFolders templateFolder, ModelFolders objectFolder)
    {
        SetPropertiesFromBase(nameOfType, templateFolder, objectFolder);

        alarmMessageElement = new TargetElement("AlarmMessage", new List<Variable> { new Variable("Text", OpcUa.DataTypes.String) });
        alarmKindIconElement = new TargetElement("AlarmKindIcon", new List<Variable> { new Variable("Path", FTOptix.Core.DataTypes.ResourceUri) });
        stationNumberIconElement = new TargetElement("StationNumberIcon", new List<Variable> { new Variable("Path", FTOptix.Core.DataTypes.ResourceUri) });

        TypeTargetElements.Add(alarmMessageElement);
        TypeTargetElements.Add(alarmKindIconElement);
        TypeTargetElements.Add(stationNumberIconElement);
    }

    public void CreateAlarmTemplateType()
    {
        TemplateType.Height = AlarmItemHeight;
        RowLayout alarmHorizontalLayout = MakeDefaultHorizontalLayout("AlarmHorizontalLayout");
        Image stationNumberIcon = MakeDefaultImageIconSize(stationNumberIconElement.BrowseName);
        stationNumberIcon.Height = AlarmItemHeight;
        stationNumberIcon.Width = AlarmItemWidth;
        Image alarmKindIcon = MakeDefaultImageIconSize(alarmKindIconElement.BrowseName);
        alarmKindIcon.Height = AlarmItemHeight;
        alarmKindIcon.Width = AlarmItemWidth;
        Label alarmMessageLabel = MakeDefaultLabel(alarmMessageElement.BrowseName);

        alarmHorizontalLayout.Add(stationNumberIcon);
        alarmHorizontalLayout.Add(alarmKindIcon);
        alarmHorizontalLayout.Add(alarmMessageLabel);
        TemplateType.Add(alarmHorizontalLayout);
    }

    //Could not make this generic :( Needs advice)
    public void MakeAlarmObjectInstance(string instanceID, StationNumberEnum stationNumber, AlarmEnum alarmKind, AlarmMessageType alarmMessageType)
    {
        IUAObject objectInstance = CreateObjectInstance(instanceID);
        objectInstance.FindVariable("StationNumberIcon_Path").Value = GetStationNumberIconPath(stationNumber);
        objectInstance.FindVariable("AlarmKindIcon_Path").Value = GetAlarmKindIconPath(alarmKind);
        objectInstance.FindVariable("AlarmMessage_Text").Value = GetAlarmMessage(alarmMessageType);
        //foreach (var variableItem in variableList)
        //{
        //    objectInstance.FindVariable(variableItem).Value = GetStationNumberIconPath(stationNumber);

        //}
    }

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