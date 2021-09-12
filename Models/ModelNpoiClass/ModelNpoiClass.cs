
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ModelNpoiClass
{

    [Module(ModuleName = "ModelNpoiClass", OnDemand = true)]
    public class ModelNpoiClass : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}
