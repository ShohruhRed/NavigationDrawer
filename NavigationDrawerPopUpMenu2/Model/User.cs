using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationDrawerPopUpMenu2.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MinLength(8)]
        public string Username { get; set; }
        [MinLength(8)]       
        public string PasswordHash { get; set; }        
        public List<Shop> Shops { get; set; }
    }
}
