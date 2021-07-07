using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Registration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;
        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }
        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = PassBox.Password.Trim();
            string pass2 = PassBox2.Password.Trim();
            string email = emailBox.Text.ToLower().Trim();
            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Это поле некоректно, минимум 5 символов";
                textBoxLogin.Background = Brushes.Red;
            }
            else if (pass.Length < 6)
            {
                PassBox.ToolTip = "Это поле некоректно, минимум 6 символов";
                PassBox.Background = Brushes.Red;
            }
            else if (pass != pass2)
            {
                PassBox.ToolTip = "Пароли не совпадают";
                PassBox.Background = Brushes.Red;
            }
            else if (!email.Contains("@") || !email.Contains("."))
            {
                emailBox.ToolTip = "Это поле некоректно";
                emailBox.Background = Brushes.Red;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                PassBox.ToolTip = "";
                PassBox.Background = Brushes.Transparent;
                PassBox2.ToolTip = "";
                PassBox2.Background = Brushes.Transparent;
                emailBox.ToolTip = "";
                emailBox.Background = Brushes.Transparent;
                MessageBox.Show("Регистриция завершена");
                User user = new User(login, pass, email);
                db.Users.Add(user);
                db.SaveChanges();
                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                this.Close();
            }
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Close();
        }
    }
}
