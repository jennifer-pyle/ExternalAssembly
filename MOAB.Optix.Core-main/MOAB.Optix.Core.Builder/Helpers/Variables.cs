using UAManagedCore;

namespace MOAB.Optix.Core.Builder.Helpers;

public class Variable
{
    public Variable(string variableBrowseName, NodeId variableDataType)
    {
        VariableBrowseName = variableBrowseName;
        VariableDataType = variableDataType;
    }

    public string VariableBrowseName { get; set; }
    public NodeId VariableDataType { get; set; }
}
