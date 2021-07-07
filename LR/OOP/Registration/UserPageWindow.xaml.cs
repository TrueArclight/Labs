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

namespace Registration
{
    /// <summary>
    /// Interaction logic for UserPageWindow.xaml
    /// </summary>
    public partial class UserPageWindow : Window
    {
        ApplicationContext db;
        public UserPageWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
            List<User> users = db.Users.ToList();
            ListOfUsers.ItemsSource = users;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow au = new AuthWindow();
            au.Show();
            Close();
        }
    }
}
