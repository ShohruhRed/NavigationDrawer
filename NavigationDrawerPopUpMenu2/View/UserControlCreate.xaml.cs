using NavigationDrawerPopUpMenu2.Model;
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

namespace NavigationDrawerPopUpMenu2
{
    /// <summary>
    /// Interação lógica para UserControlCreate.xam
    /// </summary>
    public partial class UserControlCreate : UserControl
    {
        public UserControlCreate()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                User user = new User { Username = "Test", PasswordHash = "asdasdasd" };

                Shop shop = new Shop { Name = "Shop one", Category = " Cat1", User = user };


                // добавляем объекты Book в контекст данных
                db.Users.Add(user);
                db.Shops.Add(shop);

                // сохраняем контекст данных в базу данных
                db.SaveChanges();
            }
            InitializeComponent();
        }
    }
}
