using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationDrawerPopUpMenu2.Model
{ 

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=DefaultConnection")
        {
            Database.SetInitializer<ApplicationDbContext>(new CreateDatabaseIfNotExists<ApplicationDbContext>());


        }

        public DbSet<User> Users { get; set; }
        public DbSet<Shop> Shops { get; set; }

    }
}
