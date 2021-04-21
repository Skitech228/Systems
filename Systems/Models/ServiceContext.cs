using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Systems.Models
{
    public class ServiceContext: DbContext
    {
        public ServiceContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=Service.db");
        }
    }
}
