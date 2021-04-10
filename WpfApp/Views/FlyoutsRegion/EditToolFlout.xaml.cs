using InfrastructureLibary.Constants;
using InfrastructureLibary.IServices;
using MahApps.Metro.Controls;

namespace WpfApp.Views.FlyoutsRegion
{
    /// <summary>
    /// EditToolFlout.xaml 的交互逻辑
    /// </summary>
    public partial class EditToolFlout : Flyout, IFlyoutView
    {
        public EditToolFlout()
        {
            InitializeComponent();
        }
        public string FlyoutName
        {
            get { return FlyoutNames.EditToolFlout; }
        }
    }
}
