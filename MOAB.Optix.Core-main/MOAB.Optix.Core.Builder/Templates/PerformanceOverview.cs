using FTOptix.HMIProject;
using FTOptix.UI;
using MOAB.Optix.Core.Builder.Helpers;
using UAManagedCore;
using static MOAB.Optix.Core.Builder.Helpers.Enumerations;
using static MOAB.Optix.Core.Builder.Helpers.TreeShortcuts;
using OpcUa = UAManagedCore.OpcUa;

namespace MOAB.Optix.Core.Builder.Templates;

public class PerformanceItem : TemplateTypeBaseClass
{
    private Layouts layouts = new Layouts();

    private string performanceItemKeyName;
    private string performanceItemValueName;

    private string performanceItemKeyTextVariable;
    private string performanceItemValueTextlVariable;

    public PerformanceItem(string nameOfType, UIFolders templateFolder, ModelFolders objectFolder)
    {
        SetPropertiesFromBase(nameOfType, templateFolder, objectFolder);

        performanceItemKeyName = "PerformanceItemKey";
        performanceItemValueName = "PerformanceItemValue";

        performanceItemKeyTextVariable = CreateVariableNameString(performanceItemKeyName, "Text");
        performanceItemValueTextlVariable = CreateVariableNameString(performanceItemValueName, "Text");
    }

    public void CreatePerformanceItemTemplateType()
    {
        RowLayout performanceItemColumnLayout = layouts.CreateKeyValueLeftAlignedColumnLayout(NameOfType, performanceItemKeyName, performanceItemValueName);

        TemplateType.Add(performanceItemColumnLayout);
    }

    public void CreatePerformanceItemObjectType()
    {
        IUAVariable performanceItemKey_Text = InformationModel.MakeVariable(performanceItemKeyTextVariable, OpcUa.DataTypes.String);
        IUAVariable performanceItemValue_Text = InformationModel.MakeVariable(performanceItemValueTextlVariable, OpcUa.DataTypes.String);

        ObjectType.Add(performanceItemKey_Text);
        ObjectType.Add(performanceItemValue_Text);
    }

    public void MakePerformanceItemObjectInstance(string instanceID, string performanceItemKey, string performanceItemValue)
    {
        IUAObject objectInstance = CreateObjectInstance(instanceID);

        objectInstance.FindVariable(performanceItemKeyTextVariable).Value = performanceItemKey;
        objectInstance.FindVariable(performanceItemValueTextlVariable).Value = performanceItemValue;
    }

    //Can be moved outside this class since its the container that gets added to the main screen
    public override void CreateTemplateInstanceContainer()
    {
        TemplateInstanceContainer = layouts.CreatePanelWithUpperRightButtonLayoutType("PerformanceItemListPanelType", "gear-fill.svg");

        FolderEnumLookup(TemplateInstancesFolder).Add(TemplateInstanceContainer);
    }
}