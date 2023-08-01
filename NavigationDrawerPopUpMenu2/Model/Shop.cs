using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationDrawerPopUpMenu2.Model
{
    public class Shop
    {
        public int ShopId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public User User { get; set; }
    }
}
