using FTOptix.Core;
using FTOptix.HMIProject;
using System.Reflection;
using UAManagedCore;
using static MOAB.Optix.Core.Builder.Helpers.TreeShortcuts;
using static MOAB.Optix.Core.Builder.Helpers.Enumerations;

namespace MOAB.Optix.Core.Builder.Helpers;

/// <summary>
/// This class handles creating template type instances and setting element properties to object variables from each instance
/// and finally adding the template instances to a premade parent element
/// </summary>
public static class TemplateInstanceGenerator
{
    /// <summary>
    /// Will create and add instances to a specified element. Will name the template instances the same thing as their aliased object instead, swapping out "object" for "template"
    /// </summary>
    /// <typeparam name="T1">Can be any visual element that will be the container for the instances</typeparam>
    /// <typeparam name="T2">Can be any Template Type</typeparam>
    /// <param name="locationToAddTo">
    /// Pass in the NodeID of the element you want your instances to be added to
    /// </param>
    /// <param name="templateType">
    /// The template type you are making instances of
    /// </param>
    /// <param name="objectInstanceFolder">
    /// The folder that contains the object instances to set the template instances aliases to
    /// </param>
    /// <param name="aliasName">
    /// Name of the alais that was set up on the template type
    /// </param>
    public static void GenerateTemplateInstancesFromObjectInstances<T1, T2>(T1 locationToAddTo, T2 templateType, ModelFolders objectInstanceFolder, string aliasName)
    {
        string objectInstanceFolderString = objectInstanceFolder.ToString();
        foreach (IUANode objectInstance in FolderEnumLookup(objectInstanceFolder).Children)
        {
            string templateInstanceName = objectInstance.BrowseName.Replace("Object", "Template");

            //checks to make sure it hasn't been made yet
            if (Project.Current.Find(templateInstanceName) == null)
            {
                IUAObject templateInstance = InformationModel.MakeObject(templateInstanceName, ((IUANode)templateType).NodeId);
                templateInstance.SetAlias(aliasName, objectInstance);

                SetTemplateInstancePropertiesToObjectInstanceVariables(templateInstance, objectInstance);

                PlaceTemplateInstancesInParentElement(locationToAddTo, templateInstance);
            }
        }
    }

    private static void SetTemplateInstancePropertiesToObjectInstanceVariables(IUAObject templateTypeInstance, IUANode childObjectInstance)
    {
        foreach (var variable in childObjectInstance.Children)
        {
            string objectVariableName = variable.BrowseName.Split('_').First();
            string elementPropertyTypeString = variable.BrowseName.Split('_').Last();

            IUANode templateElementWithSameNameAsObjectVariableName = templateTypeInstance.Find(objectVariableName);
            UAValue variableValue = childObjectInstance.FindVariable(variable.BrowseName).Value;

            //How to get the variable's data type? For the reflection
            if (elementPropertyTypeString.Equals("Path"))
            {
                SetElementPropertyUsingReflection(new ResourceUri(variableValue), templateElementWithSameNameAsObjectVariableName, elementPropertyTypeString);
            }
            if (elementPropertyTypeString.Equals("ImagePath"))
            {
                SetElementPropertyUsingReflection(new ResourceUri(variableValue), templateElementWithSameNameAsObjectVariableName, elementPropertyTypeString);
            }
            else if (elementPropertyTypeString.Equals("Text"))
            {
                SetElementPropertyUsingReflection(variableValue.ToString(), templateElementWithSameNameAsObjectVariableName, elementPropertyTypeString);
            }
        }
    }

    public static void SetElementPropertyUsingReflection<T1>(T1 propertyValue, IUANode targetPropertyToSet, string propertyName)
    {
        Type type = targetPropertyToSet.GetType();

        PropertyInfo prop = type.GetProperty(propertyName);

        prop.SetValue(targetPropertyToSet, propertyValue, null);
    }

    //Can be used Helpersly, move to a UI or templates class?
    public static void PlaceTemplateInstancesInParentElement<T1>(T1 typeToAddInstanceTo, IUAObject templateInstance)
    {
        ((IUANode)typeToAddInstanceTo).Add(templateInstance);
    }
}
