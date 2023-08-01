using NavigationDrawerPopUpMenu2.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace NavigationDrawerPopUpMenu2
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {

            InitializeComponent();
        }

        private async void  LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter a username and password.");
                return;
            }

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var user = await db.Users.FirstOrDefaultAsync(x => x.Username == username);

                if (user == null)
                {
                    MessageBox.Show("Incorrect password or login");
                    return;
                }

                else
                {
                    if(HashingModule.CompareWithHash(password, user))
                    {
                        ShopWindow shopPage = new ShopWindow();
                        shopPage.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect password or login");
                        return;
                    }

                }
            }
        }

        private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
        {
            Register registerPage = new Register();
            registerPage.Show();
            this.Close();
        }
    }
}
