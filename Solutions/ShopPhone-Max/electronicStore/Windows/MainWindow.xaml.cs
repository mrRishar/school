using System.Windows;
using System.Windows.Controls;
using electronicStore.WPF.MVVM.ViewModel;
using electronicStore.WPF.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace electronicStore.WPF
{
    public partial class MainWindow : Window
    {
        IServiceProvider _serviceProvider;
        public MainWindow(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
        }

        private void AboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var aboutWindow = new AboutWindow();
            aboutWindow.Show();
        }

        private void MenuRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var menuItem = (RadioButton)sender;
            if (menuItem?.IsChecked == true)
            {
                var mainVm = _serviceProvider.GetRequiredService<MainViewModel>();
                mainVm.SetHomeView(menuItem.Content.ToString());
            }
        }
    }
}