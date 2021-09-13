﻿using InfrastructureLibary.Constants;
using InfrastructureLibary.ETW;
using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System.Linq;

namespace WpfApp.ViewModels.Windows
{
    public class FirstPapgeViewModel : BindableBase, INavigationAware, IRegionMemberLifetime
    {

        public FirstPapgeViewModel (IModuleManager moduleManager, IRegionManager regionManager, IDialogService dialogService, IETWService eTWService)
        {
            _moduleManager = moduleManager;
            _regionManager = regionManager;
            _dialogService = dialogService;
            _etwService = eTWService;

            //ETW
            _etwService.ProcessingStart(nameof(FirstPapgeViewModel));
        }


        #region Fields
        private readonly IModuleManager _moduleManager;
        private readonly IRegionManager _regionManager;
        private readonly IDialogService _dialogService;
        private readonly IETWService _etwService;
        private  IRegion _navigationRegion;
        #endregion

        #region Properties
        public bool KeepAlive => true;
        public IRegion NavigationRegion => _navigationRegion ??= _regionManager.Regions[RegionNames.MainShowRegion];
        #endregion

        #region Commands

        private DelegateCommand _loadingCommand;
        public DelegateCommand LoadingCommand =>
               _loadingCommand ??= new DelegateCommand(ExecuteLoadingCommand);

        private DelegateCommand<string> _buttonCommand;
        public DelegateCommand<string> ButtonCommand =>
              _buttonCommand ??= new DelegateCommand<string>(ExecuteButton);
        #endregion

        #region Excutes
        private void ExecuteLoadingCommand()
        {
            

        }

        private void ExecuteButton(string st)
        {
            switch (st)
            {
                case "1":
                    NavigationRegion.RequestNavigate(ModelExcelExport.RegionNames.MainWindow);
                    break;
                case "2":
                    NavigationRegion.RequestNavigate(ModelExcelFontColor.RegionNames.MainWindow);
                    break;
                case "3":
                    
                    break;
                case "4":
                    
                    break;
                default:
                    break;
            }

        }
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

        #endregion



    }
}
