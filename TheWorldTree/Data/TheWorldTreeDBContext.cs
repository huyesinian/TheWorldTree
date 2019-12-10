using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheWorldTree.Models;

namespace TheWorldTree.Data
{
    public class TheWorldTreeDBContext : DbContext
    {
        public TheWorldTreeDBContext(DbContextOptions<TheWorldTreeDBContext> options) : base(options){}


        public DbSet<TreeIPInfo> TreeIPInfo { get; set; }

        public DbSet<TreeCatalos> TreeCatalos { get; set; }

        public DbSet<TreeFileSuffixType> TreeFileSuffixType { get; set; }

        public DbSet<TreeFileInfo> TreeFileInfo { get; set; }

        public DbSet<TreePress> TreePress { get; set; }

    }
}
