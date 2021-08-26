using InfrastructureLibary.Commands;
using Prism.Mvvm;
using Prism.Regions;
using InfrastructureLibary.ETW;

namespace WpfApp.ViewModels.FlyoutsRegion
{
    public class MainFloutViewModel : BindableBase
    {
        public MainFloutViewModel(IApplicationCommands applicationCommands, IRegionManager regionManager,IETWService etwcommands)
        {
            etwcommands.ProcessingStart(nameof(MainFloutViewModel));
            this.ApplicationCommands = applicationCommands;
            _regionManager = regionManager;
            etwcommands.ProcessErro(nameof(MainFloutViewModel), "sfs");
            
        }

        #region Fields

        private readonly IRegionManager _regionManager;
        private IApplicationCommands _applicationCommands;



        #endregion

        #region Properties




        #endregion

        #region Commands

        public IApplicationCommands ApplicationCommands
        {
            get { return _applicationCommands; }
            set { SetProperty(ref _applicationCommands, value); }
        }

        #endregion

        #region Excutes


        #endregion
    }
}
