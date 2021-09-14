using InfrastructureLibary.Commands;
using InfrastructureLibary.ETW;
using ModelNpoiClass;
using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System.Windows.Input;

namespace ModelExcelExport.ViewModels
{
    public class MainWindowViewModel : BindableBase, INavigationAware, IRegionMemberLifetime
    {
        public MainWindowViewModel( IRegionManager regionManager, IDialogService dialogService, IETWService eTWService, IEditCommands editCommands, INpoiService npoiService)
        {            
            _regionManager = regionManager;
            _dialogService = dialogService;
            _etwService = eTWService;
            _editCommands = editCommands;
            _npoiService = npoiService as NpoiService;
            _etwService.ProcessingStart("ModelExcelExport "+nameof(MainWindowViewModel));
        }


        #region Fields
        
        private readonly IRegionManager _regionManager;
        private readonly IDialogService _dialogService;
        private readonly IETWService _etwService;
        private IRegion _navigationRegion;
        private IEditCommands _editCommands;
        private NpoiService _npoiService;

       
        #endregion

        #region Properties
        public bool KeepAlive => true;
        public IRegion NavigationRegion => _navigationRegion ??= _regionManager.Regions[InfrastructureLibary.Constants.RegionNames.MainShowRegion];

        public string[] SheetList
        {
            get { return _npoiService.Sheets; }
            set { RaisePropertyChanged();    }
        }
        #endregion

        #region Commands

        private DelegateCommand _loadingCommand;
        public DelegateCommand LoadingCommand =>
               _loadingCommand ??= new DelegateCommand(ExecuteLoadingCommand);

        private DelegateCommand _UnLoadingCommand;
        public DelegateCommand UnLoadingCommand =>
               _UnLoadingCommand ??= new DelegateCommand(ExecuteUnLoadingCommand);

        

        private DelegateCommand<string> _buttonCommand;
        public DelegateCommand<string> ButtonCommand =>
              _buttonCommand ??= new DelegateCommand<string>(ExecuteButton);
        #endregion

        #region Excutes
        private void ExecuteLoadingCommand()
        {
            

        }
        private void ExecuteUnLoadingCommand()
        {
            

        }
        public ICommand DelegateCommand01 { get; private set; }
        private void Command01()
        {
            _npoiService.ShowDialog();
        }
        public ICommand DelegateCommand02 { get; private set; }
        private void Command02()
        {
            var temp=_npoiService.Sheets;
            
        }
        public ICommand DelegateCommand03 { get; private set; }
        private void Command03()
        {


        }
        public ICommand DelegateCommand04 { get; private set; }
        private void Command04()
        {


        }
        public ICommand DelegateCommand05 { get; private set; }
        private void Command05()
        {


        }

        private void ExecuteButton(string st)
        {
            switch (st)
            {
                case "1":
                    _npoiService.ShowDialog();
                    SheetList = _npoiService.Sheets;
                    break;
                case "2":
                    
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

            _editCommands.Command01.UnregisterCommand(DelegateCommand01);
            _editCommands.Command02.UnregisterCommand(DelegateCommand02);
            _editCommands.Command03.UnregisterCommand(DelegateCommand03);
            _editCommands.Command04.UnregisterCommand(DelegateCommand04);
            _editCommands.Command05.UnregisterCommand(DelegateCommand05);

            
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            DelegateCommand01 = new DelegateCommand(Command01);
            _editCommands.Command01.RegisterCommand(DelegateCommand01);
            DelegateCommand02 = new DelegateCommand(Command02);
            _editCommands.Command02.RegisterCommand(DelegateCommand02);
            DelegateCommand03 = new DelegateCommand(Command03);
            _editCommands.Command03.RegisterCommand(DelegateCommand03);
            DelegateCommand04 = new DelegateCommand(Command04);
            _editCommands.Command04.RegisterCommand(DelegateCommand04);
            DelegateCommand05 = new DelegateCommand(Command05);
            _editCommands.Command05.RegisterCommand(DelegateCommand05);
        }

        #endregion
        
    }
}
