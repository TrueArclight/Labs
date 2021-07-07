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
using System.Windows.Shapes;
using System.Windows.Media.Animation;
namespace Registration
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        User authUser = null;
        public AuthWindow()
        {
            InitializeComponent();
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0;
            animation.To = 445;
            animation.Duration = TimeSpan.FromSeconds(2);
            AuthButton.BeginAnimation(Button.WidthProperty, animation);
        }
        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = PassBox.Password.Trim();

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
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                PassBox.ToolTip = "";
                PassBox.Background = Brushes.Transparent;
                using (ApplicationContext context = new ApplicationContext())
                {
                    authUser = context.Users.Where(b=>b.login == login && b.pass == pass).FirstOrDefault();
                }
                if(authUser != null)
                {
                    UserPageWindow upw = new UserPageWindow();
                    upw.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Пользователь не найден");
                }
                    
            }
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }

}
