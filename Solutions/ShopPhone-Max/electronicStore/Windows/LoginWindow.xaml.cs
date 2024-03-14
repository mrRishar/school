using System.Windows;
using System.Windows.Media;

namespace electronicStore
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string Email = TexBoxEmail.Text.Trim().ToLower();
            string Pass = PassBox.Password.Trim();

            if (Pass.Length < 8)
            {
                PassBox.ToolTip = "Password was not entered correctly";
                PassBox.Background = Brushes.DarkRed;
            }
            else if (Email.Length < 5 || !Email.Contains("@") || !Email.Contains("."))
            {
                TexBoxEmail.ToolTip = "Email was not entered correctly";
                TexBoxEmail.Background = Brushes.DarkRed;
            }
            else
            {
                TexBoxEmail.ToolTip = "";
                TexBoxEmail.Background = Brushes.Transparent;
                PassBox.ToolTip = "";
                PassBox.Background = Brushes.Transparent;

                MessageBox.Show("Everything is fine");
            }
        }
    }
}