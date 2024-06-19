using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOAB.Optix.Core.Builder.Pages.Station;

/// <summary>
/// Do not review
/// </summary>
public class StationView
{
    public StationView()
    {
    }

    //public string uITemplatesPath = "UI/Components/Layout/Templates/";
    //public string modelObjectsPath = "Model/Components/";

    //public void CreateStationTemplateType()
    //{
    //    var templateFolder = Project.Current.Get<Folder>(uITemplatesPath + "Station");

    //    var stationTemplateType = InformationModel.Make<RectangleType>("StationTemplateType");

    //    var stationAlias = InformationModel.MakeAlias("StationObjectAlias");

    //    stationTemplateType.Width = 150;
    //    stationTemplateType.Height = 100;
    //    stationTemplateType.FillColor = new Color(0xFF00FF00);

    //    stationTemplateType.Add(stationAlias);

    //    var lblStationNumber = InformationModel.Make<Label>("lblStationNumber");
    //    lblStationNumber.Text = "Station Number: ";
    //    stationTemplateType.Add(lblStationNumber);
    //    var lblStationNumberValue = InformationModel.Make<Label>("lblStationNumberValue");
    //    lblStationNumberValue.Text = "";
    //    lblStationNumberValue.HorizontalAlignment = HorizontalAlignment.Right;
    //    stationTemplateType.Add(lblStationNumberValue);

    //    var lblNumberAlerts = InformationModel.Make<Label>("lblNumberAlerts");
    //    lblNumberAlerts.Text = "Number Alerts: ";
    //    lblNumberAlerts.TopMargin = 20;
    //    stationTemplateType.Add(lblNumberAlerts);
    //    var lblNumberAlertsValue = InformationModel.Make<Label>("lblNumberAlertsValue");
    //    lblNumberAlertsValue.Text = "";
    //    lblNumberAlertsValue.TopMargin = 20;
    //    lblNumberAlertsValue.HorizontalAlignment = HorizontalAlignment.Right;
    //    stationTemplateType.Add(lblNumberAlertsValue);

    //    templateFolder.Add(stationTemplateType);
    //}

    //public void CreateStationObjectType()
    //{
    //    var stationObjectType = InformationModel.MakeObjectType("StationObjectType");

    //    IUAVariable stationNumber = InformationModel.MakeVariable("StationNumber", OpcUa.DataTypes.String);
    //    var name = InformationModel.MakeVariable("Name", OpcUa.DataTypes.String);
    //    IUAVariable numberAlerts = InformationModel.MakeVariable("NumberAlerts", OpcUa.DataTypes.UInt16);
    //    var palletNumber = InformationModel.MakeVariable("PalletNumber", OpcUa.DataTypes.UInt16);
    //    var timeDown = InformationModel.MakeVariable("TimeDown", OpcUa.DataTypes.UInt16);
    //    var sumRejectedParts = InformationModel.MakeVariable("SumRejectedParts", OpcUa.DataTypes.UInt16);

    //    stationObjectType.Add(stationNumber);
    //    stationObjectType.Add(name);
    //    stationObjectType.Add(numberAlerts);
    //    stationObjectType.Add(palletNumber);
    //    stationObjectType.Add(timeDown);
    //    stationObjectType.Add(sumRejectedParts);

    //    Project.Current.Get(modelObjectsPath + "Station").Add(stationObjectType);
    //}

    //public void CreateStationObjectInstance()
    //{
    //    var objectInstanceFolder = InformationModel.Make<Folder>("ObjectInstances");
    //    Project.Current.Get(modelObjectsPath + "Station").Add(objectInstanceFolder);
    //    Random rnd = new Random();
    //    for (int i = 1; i <= 3; i++)
    //    {
    //        var stationObjectType = Project.Current.Get(modelObjectsPath + "Station/StationObjectType");
    //        var stationObject = InformationModel.MakeObject("StationObjectInstance" + i, stationObjectType.NodeId);

    //        stationObject.FindVariable("StationNumber").Value = i;
    //        stationObject.FindVariable("Name").Value = "Station " + i;
    //        stationObject.FindVariable("NumberAlerts").Value = rnd.Next();
    //        stationObject.FindVariable("PalletNumber").Value = rnd.Next(); ;
    //        stationObject.FindVariable("TimeDown").Value = rnd.Next(); ;
    //        stationObject.FindVariable("SumRejectedParts").Value = rnd.Next();

    //        objectInstanceFolder.Add(stationObject);
    //    }
    //}

    //[ExportMethod]
    //public void CreateStationTemplateInstance()
    //{
    //    AddVerticalAlignmentForVisualPurposes();

    //    for (int i = 1; i <= 3; i++)
    //    {
    //        var stationTemplateType = Project.Current.Get(uITemplatesPath + "Station/StationTemplateType");
    //        var stationTemplateInstance = InformationModel.MakeObject("StationTemplateInstance" + i, stationTemplateType.NodeId);
    //        Project.Current.Get("UI/MainWindow/VerticalAlignmentForVisualPurposes").Children.Add(stationTemplateInstance);

    //        AddAlias(i);

    //        var stationObjectInstance = Project.Current.Get(modelObjectsPath + "Station/ObjectInstances/StationObjectInstance" + i);
    //        var stationNumber = stationObjectInstance.FindVariable("StationNumber");
    //        var numberAlerts = stationObjectInstance.FindVariable("NumberAlerts");

    //        var lblStationNumberValue = stationTemplateInstance.Find<Label>("lblStationNumberValue");
    //        lblStationNumberValue.Text = stationNumber.Value;

    //        var lblNumberAlertsValue = stationTemplateInstance.Find<Label>("lblNumberAlertsValue");
    //        lblNumberAlertsValue.Text = numberAlerts.Value;
    //    }
    //}

    //private void AddAlias(int i)
    //{
    //        var stationTemplate1 = Project.Current.Get<Rectangle>("UI/MainWindow/VerticalAlignmentForVisualPurposes/StationTemplateInstance" + i);
    //        stationTemplate1.SetAlias("StationObjectAlias", Project.Current.Get(modelObjectsPath + "Station/ObjectInstances/StationObjectInstance" + i));
    //        stationTemplate1.LeftMargin = (stationTemplate1.Width + 5) * (i - 1);
    //        stationTemplate1.TopMargin = 150;
    //}

    //private void AddVerticalAlignmentForVisualPurposes()
    //{
    //    var verticalAlignment = InformationModel.Make<ColumnLayout>("VerticalAlignmentForVisualPurposes");
    //    Project.Current.Get("UI/MainWindow").Children.Add(verticalAlignment);
    //}

    ////////////////////////////////////////////////////////////
    /////make generic methods for making the instances of object type and template types?
}
