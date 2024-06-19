using FTOptix.Core;
using FTOptix.HMIProject;
using FTOptix.UI;
using MOAB.Optix.Core.Builder.Pages.Home;
using System;
using System.Collections.Generic;
using UAManagedCore;
using static MOAB.Optix.Core.Builder.Helpers.Enumerations;
using static MOAB.Optix.Core.Builder.Helpers.HmiColors;
using static MOAB.Optix.Core.Builder.Helpers.HmiStyledElements;
using static MOAB.Optix.Core.Builder.Helpers.HmiStyles;
using static MOAB.Optix.Core.Builder.Helpers.TreeShortcuts;
using OpcUa = UAManagedCore.OpcUa;

namespace MOAB.Optix.Core.Builder.Templates;

public class LocalPageNavigation : TemplateTypeBaseClass
{
    private Home home = new Home();
    public PanelLoader LocalContentPanelLoader;

    public LocalPageNavigation(string nameOfType, UIFolders templateFolder, ModelFolders objectFolder)
    {
        SetPropertiesFromBase(nameOfType, templateFolder, objectFolder);
        CreateTemplateInstanceContainer();
        navigationTabElementName = "LocalNavigationTabOption";
        localNavigationTabOptionTextVariable = CreateVariableNameString(navigationTabElementName, "Text");
    }
    private string navigationTabElementName;
    private string localNavigationTabOptionTextVariable;

    public void CreateLocalNavigationOptionButtonTemplateType()
    {
        TemplateType.HorizontalAlignment = HorizontalLeft;
        Button tabOption = MakeDefaultButton(navigationTabElementName);
        tabOption.Text = NameOfType;
        tabOption.TextColor = White;
        tabOption.Height = LocalNavigationButtonHeight;
        tabOption.Width = LocalNavigationButtonWidth;
        tabOption.VerticalAlignment = VerticalBottom;
        tabOption.HorizontalAlignment = HorizontalLeft;

        AttachClickEvents(tabOption);

        TemplateType.Add(tabOption);
    }

    public void CreateLocalNavigationOptionButtonObjectType()
    {
        IUAVariable tabOption = InformationModel.MakeVariable(localNavigationTabOptionTextVariable, OpcUa.DataTypes.String);

        ObjectType.Add(tabOption);
    }

    public void MakeLocalNavigationOptionButtonObjectInstance(string instanceID, string option)
    {
        IUAObject objectInstance = CreateObjectInstance(instanceID);
        objectInstance.FindVariable(localNavigationTabOptionTextVariable).Value = option;
    }

    public override void CreateTemplateInstanceContainer()
    {
        PanelType localPageNavigation = MakeDefaultPanelType("LocalPageNavigationPanelType");
        ColumnLayout verticalLayout = MakeDefaultVerticalLayout("LocalPageNavigationContainer");
        RowLayout localPageNavigationOptionsHorizontalLayout = MakeDefaultHorizontalLayout("LocalPageNavigationOptionsHorizontalLayout");
        Rectangle dividerLine = MakeDefaultRectangle("DividerLine");
        LocalContentPanelLoader = MakeDefaultPanelLoaderSection("LocalContentPanelLoader");
        LocalContentPanelLoader.Panel = home.LinePanelType.NodeId;
        Rectangle backgroundOfMainPanelLoader = GetBackgroundOfPanelLoaderSection("MainContentPanelLoader");
        backgroundOfMainPanelLoader.Visible = false;

        localPageNavigationOptionsHorizontalLayout.VerticalAlignment = VerticalTop;
        localPageNavigationOptionsHorizontalLayout.Height = 35;

        localPageNavigation.Add(verticalLayout);
        verticalLayout.Add(localPageNavigationOptionsHorizontalLayout);
        verticalLayout.Add(LocalContentPanelLoader);

        TemplateInstanceContainer = localPageNavigation;
        FolderEnumLookup(TemplateInstancesFolder).Add(TemplateInstanceContainer);
    }

    public void AttachClickEvents(Button newButton)
    {
        MakeEventHandler(newButton,
                         FTOptix.UI.ObjectTypes.MouseClickEvent,
                         LocalContentPanelLoader,
                         "ChangePanel",
                         new List<Tuple<string, NodeId, object>>
            {
                    new("NewPanel", FTOptix.Core.DataTypes.VariablePointer, NodeId.Empty),
                    new("AliasNode", FTOptix.Core.DataTypes.VariablePointer, NodeId.Empty)
            }
            );

        var changeNewButtonEventHandler = newButton.Get("EventHandler");
        var variableToModifyArgumentVariable = changeNewButtonEventHandler.GetVariable("MethodsToCall/MethodContainer1/InputArguments/NewPanel");
        IUAVariable tempVar = null;
        variableToModifyArgumentVariable.SetDynamicLink(tempVar);
        //variableToModifyArgumentVariable.GetVariable("DynamicLink").Value = "Mikron_MOAB_HMI/UI/Components/Page/Home/Module/ModuleSVGPanel";
    }

    private FTOptix.CoreBase.EventHandler MakeEventHandler(
                                                            IUANode parentNode, // The parent node to which the event handler is to be added
                                                            NodeId listenEventTypeId, // The NodeID of the event to be listened
                                                            IUAObject callingObject, // The object on which the method is to be executed
                                                            string methodName, // The name of the method to be called
                                                            List<Tuple<string, NodeId, object>> arguments = null // List of input arguments (name, data type NodeID, value)
                                                           )
    {
        // Create event handler object
        var eventHandler = InformationModel.MakeObject<FTOptix.CoreBase.EventHandler>("EventHandler");
        parentNode.Add(eventHandler);

        // Set the ListenEventType variable value to the Node ID of the event to be listened
        eventHandler.ListenEventType = listenEventTypeId;

        // Create method container
        var methodContainer = InformationModel.MakeObject("MethodContainer1");
        eventHandler.MethodsToCall.Add(methodContainer);

        // Create the ObjectPointer variable and set its value to the object on which the method is to be executed
        var objectPointerVariable = InformationModel.MakeVariable<NodePointer>("ObjectPointer", OpcUa.DataTypes.NodeId);
        objectPointerVariable.Value = callingObject.NodeId;
        methodContainer.Add(objectPointerVariable);

        // Create the Method variable and set its value to the name of the method to be called
        var methodNameVariable = InformationModel.MakeVariable("Method", OpcUa.DataTypes.String);
        methodNameVariable.Value = methodName;
        methodContainer.Add(methodNameVariable);

        if (arguments != null)
            CreateInputArguments(methodContainer, arguments);

        return eventHandler;
    }

    private void CreateInputArguments(IUANode methodContainer, List<Tuple<string, NodeId, object>> arguments)
    {
        IUAObject inputArguments = InformationModel.MakeObject("InputArguments");
        methodContainer.Add(inputArguments);

        foreach (var arg in arguments)
        {
            var argumentVariable = inputArguments.Context.NodeFactory.MakeVariable(
                NodeId.Random(inputArguments.NodeId.NamespaceIndex),
                arg.Item1,
                arg.Item2,
                OpcUa.VariableTypes.BaseDataVariableType,
                false,
                arg.Item3);

            inputArguments.Add(argumentVariable);
        }
    }
}