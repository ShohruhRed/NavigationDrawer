using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationDrawerPopUpMenu2.Model
{
    static class HashingModule
    {
        public static string Hash(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password, 5);
        }
        
        public static bool CompareWithHash(string password, User user)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, user.PasswordHash);
        }
    }
}
