using InfrastructureLibary.Commands;
using InfrastructureLibary.ETW;
using Prism.Mvvm;

namespace WpfApp.ViewModels.FlyoutsRegion
{
    public class EditToolFloutViewModel : BindableBase
    {
        public EditToolFloutViewModel( IEditCommands editCommands, IETWService eTWService)
        {
            EditCommands = editCommands;

            //ETW
            _etwService.ProcessingStart(nameof(MainWindowViewModel));
        }

        #region Fields      
        private readonly IETWService _etwService;
        private bool _isCanExcute=true;
        private IEditCommands _editCommands;
        #endregion

        #region Properties  
        public bool IsCanExcute
        {
            get { return _isCanExcute; }
            set { SetProperty(ref _isCanExcute, value); }
        }

        #endregion

        #region Commands
        public IEditCommands EditCommands
        {
            get { return _editCommands; }
            set { SetProperty(ref _editCommands, value); }
        }  
        #endregion

        #region Excutes

      
        #endregion
    }
}
