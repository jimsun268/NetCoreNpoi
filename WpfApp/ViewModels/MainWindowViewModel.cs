using InfrastructureLibary.Constants;
using InfrastructureLibary.ETW;
using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using WpfApp.Views.FlyoutsRegion;
using WpfApp.Views.Windows;

namespace WpfApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel(IModuleManager moduleManager, IRegionManager regionManager, IDialogService dialogService,IETWService eTWService)
        {
            _moduleManager = moduleManager;
            _regionManager = regionManager;
            _dialogService = dialogService;
            _etwService = eTWService;
            _etwService.ProcessingStart(nameof(MainWindowViewModel));
            _moduleManager.LoadModuleCompleted += ModuleManager_LoadModuleCompleted;            
        }

        #region Fields
        private readonly IModuleManager _moduleManager;
        private readonly IRegionManager _regionManager;
        private readonly IDialogService _dialogService;
        private readonly IETWService _etwService;
        
        #endregion

        #region Properties


        #endregion

        #region Commands

        private DelegateCommand _loadingCommand;
        public DelegateCommand LoadingCommand =>
               _loadingCommand ??= new DelegateCommand(ExecuteLoadingCommand);
        #endregion

        #region Excutes
        private void ExecuteLoadingCommand()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.LeftWindowRegion, typeof(LeftWindowRegion));
            _regionManager.RegisterViewWithRegion(RegionNames.FlyoutRegion, typeof(MainFlout));
            _regionManager.RegisterViewWithRegion(RegionNames.FlyoutRegion, typeof(EditToolFlout));
            
            IRegion region = _regionManager.Regions[RegionNames.MainShowRegion];
            region.RequestNavigate("FirstPapge", NavigationCompelted);

        }
        private void ModuleManager_LoadModuleCompleted(object sender, LoadModuleCompletedEventArgs e)
        {
            string name = e.ModuleInfo.ModuleName;
            _etwService.ProcessInformational(nameof(MainWindowViewModel),"{name} loaded!");
        }        
        private void NavigationCompelted(NavigationResult obj)
        {


        }
        #endregion
    }
}
