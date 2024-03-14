using electronicStore.WPF.MVVM.View;
using electronicStore.WPF.MVVM.ViewModel;
using electronicStore.WPF.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace electronicStore.WPF
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
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

            }
        }
    }
}