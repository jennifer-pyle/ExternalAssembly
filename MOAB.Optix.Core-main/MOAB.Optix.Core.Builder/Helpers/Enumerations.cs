using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOAB.Optix.Core.Builder.Helpers;

public static class Enumerations
{
    //Why can I access this without having the static declaration?
    public enum AlarmEnum
    {
        Ready,
        Warning,
        Error
    }

    public enum AlarmMessageType
    {
        Short,
        Medium,
        Long
    }

    public enum HomeNavigationEnum
    {
        Line,
        Cell,
        Module
    }

    public enum NavigationEnum
    {
        Home,
        Station,
        None
    }

    public enum StationNavigationEnum
    {
        Summary,
    }

    public enum StationNumberEnum
    {
        Station1,
        Station2,
        Station3,
        Station4,
        Station5,
        Station6,
        Station7,
        Station8,
        Station9,
        Station10,
        Station11,
        Station12,
        Station13,
        Station14,
        Station15,
        Station16,
        Station17,
        Station18,
        Station19,
        Station20
    }

    public enum ModelFolders
    {
        Objects, Variables, ObjectsHomeObjectInstances, ObjectsHome, ObjectsStationObjectInstances, ObjectsStation, ObjectsAlarmObjectInstances, ObjectsAlarm, ObjectsNavigationObjectInstances, ObjectsNavigation, ObjectsHeaderObjectInstances, ObjectsHeader, ObjectsDeviceObjectsObjectInstances, ObjectsDeviceObjects, ObjectsHomePerformanceObjectInstances, ObjectsHomePerformance, ObjectsLocalPageNavigation, ObjectsLocalPageNavigationObjectInstances
    }

    public enum UIFolders
    {
        Layout, Page, VisionViewer, DigitalServices, Devices, LayoutTemplates, LayoutNavigation, PageTemplates, PageHome, PageStation, PageFlyouts, LayoutTemplatesGenericTemplateInstances, LayoutTemplatesGeneric, LayoutTemplatesHomeTemplateInstances, LayoutTemplatesHome, LayoutTemplatesStationTemplateInstances, LayoutTemplatesStation, LayoutTemplatesGenericAlarmTemplateInstances, LayoutTemplatesGenericAlarm, PageHomeLine, PageHomeCell, PageHomeModule, PageStationOverview, PageStationCams, PageStationManual, PageStationConfiguration, PageStationData
    }
}
