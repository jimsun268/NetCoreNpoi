using InfrastructureLibary.ETW;
using ModelExcelExport.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelExcelExport
{
    [Module(ModuleName = "ModelExcelExport", OnDemand = true)]
    public class ModelExcelExport : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
            var regionManager = containerProvider.Resolve<IRegionManager>();
            //regionManager.RegisterViewWithRegion(RegionNames.FlyoutRegion, typeof(SearchLandFlyout));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.Register<ILandService, LandService>();
            containerRegistry.RegisterForNavigation<MainWindow>(RegionNames.MainWindow );
            containerRegistry.Register<IETWService, ETWService>();
        }
    }
}
