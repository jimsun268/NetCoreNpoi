using InfrastructureLibary.Commands;
using InfrastructureLibary.ETW;
using NpoiLibary;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.ViewModels.Windows
{
    public class FirstPapgeViewModel : BindableBase, INavigationAware, IRegionMemberLifetime
    {


        public FirstPapgeViewModel (IApplicationCommands applicationCommands, IRegionManager regionManager, IETWService etwcommands)
        {

        }
        public bool KeepAlive => true;

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
           
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }
    }
}
