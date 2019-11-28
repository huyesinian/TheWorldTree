using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TheWorldTree.Data
{
    public class TheWorldTreeDBContext : DbContext
    {
        public TheWorldTreeDBContext(DbContextOptions<TheWorldTreeDBContext> options) : base(options)
        {
            if (Database.GetPendingMigrations().Any())
            {
                //执行迁移
                Database.Migrate();
            }
        }


        //public DbSet<Movie> Movie { get; set; }

    }
}
