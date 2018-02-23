using Prism.Modularity;
using Prism.Regions;

namespace Wpf.Prism.Unity.ModularApp.ModuleB
{
    public class ModuleB : IModule
    {
        private readonly IRegionViewRegistry _regionViewRegistry;

        public ModuleB(IRegionViewRegistry registry)
        {
            _regionViewRegistry = registry;
        }

        public void Initialize()
        {
            _regionViewRegistry.RegisterViewWithRegion(nameof(ModuleB), typeof(Views.ModuleBView));
        }
    }
}
