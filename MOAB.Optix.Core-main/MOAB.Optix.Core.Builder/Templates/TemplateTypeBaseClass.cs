using FTOptix.HMIProject;
using FTOptix.UI;
using MOAB.Optix.Core.Builder.Helpers;
using UAManagedCore;
using static MOAB.Optix.Core.Builder.Helpers.Enumerations;
using static MOAB.Optix.Core.Builder.Helpers.HmiStyledElements;
using static MOAB.Optix.Core.Builder.Helpers.HmiStyles;
using static MOAB.Optix.Core.Builder.Helpers.TreeShortcuts;

namespace MOAB.Optix.Core.Builder.Templates;
public class TemplateTypeBaseClass
{
    public TemplateTypeBaseClass()
    {
    }

    public string NameOfType;
    public UIFolders TemplateFolder;
    public ModelFolders ObjectFolder;

    public PanelType TemplateType;
    public IUAObjectType ObjectType;

    public UIFolders TemplateInstancesFolder;
    public ModelFolders ObjectInstancesFolder;

    public string TemplateTypeName;
    public string ObjectTypeName;

    public string ObjectAliasName;
    public string ObjectInstanceNamePrefix;

    public PanelType TemplateInstanceContainer;
    public ColumnLayout LocationFromDefaultContainerToAddInstances;

    public List<TargetElement> TypeTargetElements = new List<TargetElement>();

    public void CreateVariablesForElement(string elementBrowseName, string[] elementProperties)
    {
        foreach (string property in elementProperties)
        {
            string variable = CreateVariableNameString(elementBrowseName, property);
        }
    }

    public void SetPropertiesFromBase(string nameOfType, UIFolders templateFolder, ModelFolders objectFolder)
    {
        NameOfType = nameOfType;
        TemplateFolder = templateFolder;
        ObjectFolder = objectFolder;

        TemplateInstancesFolder = GetTemplateInstanceFolderEnum(templateFolder);
        ObjectInstancesFolder = GetObjectInstanceFolderEnum(objectFolder);

        TemplateTypeName = CreateTemplateTypeName(nameOfType);
        ObjectTypeName = CreateObjectTypeName(nameOfType);

        ObjectAliasName = CreateObjectAliasName(nameOfType);
        ObjectInstanceNamePrefix = GetObjectInstanceNamePrefix(nameOfType);

        CreateTemplateType();
        CreateObjectType();
    }

    public void CreateTemplateType()
    {
        TemplateType = MakeDefaultPanelType(TemplateTypeName);

        IUAVariable templateTypeAlias = InformationModel.MakeAlias(ObjectAliasName);
        TemplateType.Add(templateTypeAlias);

        FolderEnumLookup(TemplateFolder).Add(TemplateType);
    }

    public void CreateObjectType()
    {
        ObjectType = InformationModel.MakeObjectType(ObjectTypeName);
        FolderEnumLookup(ObjectFolder).Add(ObjectType);
    }

    public IUAObject CreateObjectInstance(string instanceID)
    {
        IUAObject objectInstance = InformationModel.MakeObject(ObjectInstanceNamePrefix + instanceID, ObjectType.NodeId);
        FolderEnumLookup(ObjectInstancesFolder).Add(objectInstance);
        return objectInstance;
    }

    public virtual void CreateTemplateInstanceContainer()
    {
        PanelType defaultContainerPanelType = MakeDefaultPanelType(TemplateTypeName + "DefaultInstancesContainer");
        ColumnLayout columnLayout = MakeDefaultVerticalLayout("VerticalLayout");

        defaultContainerPanelType.VerticalAlignment = VerticalCenter;
        defaultContainerPanelType.HorizontalAlignment = HorizontalCenter;
        defaultContainerPanelType.Height = 100;
        defaultContainerPanelType.Width = 100;

        defaultContainerPanelType.Add(columnLayout);

        TemplateInstanceContainer = defaultContainerPanelType;
        LocationFromDefaultContainerToAddInstances = TemplateInstanceContainer.Find<ColumnLayout>("VerticalLayout");

        FolderEnumLookup(TemplateInstancesFolder).Add(TemplateInstanceContainer);
    }

    //public T GetLocationFromContainerToAddInstances<T>(string elementName)
    //{
    //    return (T)TemplateInstanceContainer.Find(elementName);
    //}

    public UIFolders GetTemplateInstanceFolderEnum(UIFolders templateFolder)
    {
        string templateInstanceFolderString = templateFolder.ToString() + "TemplateInstances";
        UIFolders templateInstanceFolderEnum = (UIFolders)System.Enum.Parse(typeof(UIFolders), templateInstanceFolderString);
        return templateInstanceFolderEnum;
    }

    public ModelFolders GetObjectInstanceFolderEnum(ModelFolders objectFolder)
    {
        string objectInstanceFolderString = objectFolder.ToString() + "ObjectInstances";
        ModelFolders objectInstanceFolderEnum = (ModelFolders)System.Enum.Parse(typeof(ModelFolders), objectInstanceFolderString);
        return objectInstanceFolderEnum;
    }

    public string CreateTemplateTypeName(string name)
    {
        return name + "TemplateType";
    }

    public string CreateObjectTypeName(string name)
    {
        return name + "ObjectType";
    }

    public string GetObjectInstanceNamePrefix(string name)
    {
        return name + "Object";
    }

    public string CreateObjectAliasName(string name)
    {
        return name + "ObjectAlias";
    }

    public string CreateVariableNameString(string elementName, string propertyType)
    {
        return elementName + "_" + propertyType;
    }
}

