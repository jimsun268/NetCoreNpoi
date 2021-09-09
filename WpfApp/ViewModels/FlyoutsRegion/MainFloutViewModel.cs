using InfrastructureLibary.Constants;
using InfrastructureLibary.ETW;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace WpfApp.ViewModels.FlyoutsRegion
{
    public class MainFloutViewModel : BindableBase
    {
        public MainFloutViewModel( IRegionManager regionManager,IETWService etwcommands)
        {
            _regionManager = regionManager;
            _etwService = etwcommands;
        }

        #region Fields
        private readonly IRegionManager _regionManager;
        IRegion _navigationRegion;
        private readonly IETWService _etwService;
        #endregion

        #region Properties
        public IRegion NavigationRegion => _navigationRegion ??= _regionManager.Regions[RegionNames.MainShowRegion];

        #endregion

        #region Commands
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
                    NavigationRegion.RequestNavigate("FirstPapge");
                    break;
                case "3":
                    NavigationRegion.RequestNavigate(ModelExcelFontColor.RegionNames.MainWindow );
                    break;
                case "4":
                    NavigationRegion.NavigationService.Journal.GoForward();
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
