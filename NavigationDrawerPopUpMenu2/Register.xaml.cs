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
using System.Windows.Shapes;

namespace NavigationDrawerPopUpMenu2
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        
        public Register()
        {
            InitializeComponent();
        }

        private async void RegisterBtn(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter a username and password.");
                return;
            }

            if(username.Length < 8 || password.Length < 8)
            {
                MessageBox.Show("Username and password must be more than 8 characters long");
                return;
            }

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var user = await db.Users.FirstOrDefaultAsync(x => x.Username == username);

                if(user != null)
                {
                    MessageBox.Show("User with this name already exists");
                }

                else
                {
                    var hash = HashingModule.Hash(password);

                    var newUser = new User
                    {
                        Username = username,
                        PasswordHash = hash
                    };

                    db.Users.Add(newUser);

                    db.SaveChanges();

                }
            }

            

            ShopWindow shopPage = new ShopWindow();
            shopPage.Show();
            this.Close();
        }
    }
}
