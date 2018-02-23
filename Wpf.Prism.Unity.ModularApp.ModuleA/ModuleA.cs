using Prism.Modularity;
using Prism.Regions;

namespace Wpf.Prism.Unity.ModularApp.ModuleA
{
    public class ModuleA : IModule
    {
        private readonly IRegionViewRegistry _regionViewRegistry;

        public ModuleA(IRegionViewRegistry registry)
        {
            _regionViewRegistry = registry;
        }

        public void Initialize()
        {
            _regionViewRegistry.RegisterViewWithRegion(nameof(ModuleA), typeof(Views.ModuleAView));
        }
    }
}
