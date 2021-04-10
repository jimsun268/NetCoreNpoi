using InfrastructureLibary.Constants;
using InfrastructureLibary.IServices;
using MahApps.Metro.Controls;

namespace WpfApp.Views.FlyoutsRegion
{
    /// <summary>
    /// MainFlout.xaml 的交互逻辑
    /// </summary>
    public partial class MainFlout : Flyout, IFlyoutView
    {
        public MainFlout()
        {
            InitializeComponent();
        }
        public string FlyoutName
        {
            get { return FlyoutNames.MainFlout; }
        }
    }
}
