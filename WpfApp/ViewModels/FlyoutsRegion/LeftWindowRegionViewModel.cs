using InfrastructureLibary.Commands;
using InfrastructureLibary.Constants;
using InfrastructureLibary.ETW;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace WpfApp.ViewModels.FlyoutsRegion
{
    public class LeftWindowRegionViewModel : BindableBase
    {
        public LeftWindowRegionViewModel(IApplicationCommands applicationCommands, IRegionManager regionManager, IETWService etwcommands)
        {
            this.ApplicationCommands = applicationCommands;
            _regionManager = regionManager;
            _etwService = etwcommands;

            //ETW
            _etwService.ProcessingStart(nameof(LeftWindowRegionViewModel));
        }

        #region Fields
        private readonly IRegionManager _regionManager;
        private IApplicationCommands _applicationCommands;
        IRegion _navigationRegion;
        private readonly IETWService _etwService;
        #endregion

        #region Properties
        public IRegion NavigationRegion => _navigationRegion ??= 
            _regionManager.Regions[RegionNames.MainShowRegion];
        #endregion

        #region Commands
        public IApplicationCommands ApplicationCommands
        {
            get { return _applicationCommands; }
            set { SetProperty(ref _applicationCommands, value); }
        }
        private DelegateCommand<string> _buttonCommand;
        public DelegateCommand<string> ButtonCommand =>
              _buttonCommand ??= new DelegateCommand<string>(ExecuteButton);
        #endregion

        #region Excutes
        private void ExecuteButton(string st)
        {
            switch (st)
            {
                case "1":
                    NavigationRegion.NavigationService.Journal.GoBack();
                    break;
                case "2":
                    NavigationRegion.NavigationService.Journal.GoForward();
                    break;
                case "3":
                    NavigationRegion.RequestNavigate(HelpClass.RegionNames.MainWindow);
                    break;
                case "4":
                    
                    break;
                default:
                    break;
            }
        }

        #endregion

    }
}
