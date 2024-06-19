namespace MOAB.Optix.Core.Builder.Helpers;

public class TargetElement
{
    public TargetElement(string browseName, List<Variable> variablesToSet)
    {
        BrowseName = browseName;
        VariablesToSet = variablesToSet;
    }
    public string BrowseName { get; set; }
    public List<Variable> VariablesToSet { get; set; }
}
