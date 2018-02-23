using Prism.Modularity;
using Prism.Regions;
using Wpf.Prism.Unity.ModularApp.ModuleC.Views;

namespace Wpf.Prism.Unity.ModularApp.ModuleC
{
    [Module(ModuleName = nameof(ModuleC))]
    public class ModuleC : IModule
    {
        private readonly IRegionViewRegistry _regionViewRegistry;

        public ModuleC(IRegionViewRegistry registry)
        {
            _regionViewRegistry = registry;
        }

        public void Initialize()
        {
            _regionViewRegistry.RegisterViewWithRegion(nameof(ModuleC), typeof(ModuleCView));
        }
    }
}
