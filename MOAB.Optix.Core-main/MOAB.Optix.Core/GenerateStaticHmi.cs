using FTOptix.HMIProject;
using FTOptix.UI;
using UAManagedCore;
using MOAB.Optix.Core.Builder;

namespace MOAB.Optix.Core
{
    public class GenerateStaticHmi
    {
        private GenerateStaticHMI StaticBuilder;

        public GenerateStaticHmi()
        {

        }

        public void Build()
        {
            StaticBuilder = new GenerateStaticHMI();
            StaticBuilder.Build();
        }
    }
}
