using FTOptix.UI;

using UAManagedCore;
using static MOAB.Optix.Core.Builder.Helpers.Enumerations;
using static MOAB.Optix.Core.Builder.Helpers.HmiStyledElements;
using static MOAB.Optix.Core.Builder.Helpers.TreeShortcuts;

namespace MOAB.Optix.Core.Builder.Pages.Home;

public class Home
{
    public PanelType LinePanelType;
    public PanelType CellPanelType;
    public PanelType ModulePanelType;

    public Home()
    {
        CreateLineSVGPanelType();
        CreateCellSVGPanelType();
        CreateModuleSVGPanelType();
    }

    public void CreateLineSVGPanelType()
    {
        LinePanelType = MakeDefaultPanelType("LineSVGPanel");
        Image lineSvg = MakeDefaultImage("LineSVG", "LineView.svg");
        LinePanelType.Add(lineSvg);
        FolderEnumLookup(UIFolders.PageHomeLine).Add(LinePanelType);
    }

    public void CreateCellSVGPanelType()
    {
        CellPanelType = MakeDefaultPanelType("CellSVGPanel");
        Image cellSvg = MakeDefaultImage("CellSVG", "LineView.svg");
        CellPanelType.Add(cellSvg);
        FolderEnumLookup(UIFolders.PageHomeCell).Add(CellPanelType);
    }

    public void CreateModuleSVGPanelType()
    {
        ModulePanelType = MakeDefaultPanelType("ModuleSVGPanel");
        Image moduleSvg = MakeDefaultImage("ModuleSVG", "NEWStationsWithNumbers.svg");
        ModulePanelType.Add(moduleSvg);
        FolderEnumLookup(UIFolders.PageHomeModule).Add(ModulePanelType);
    }
}
