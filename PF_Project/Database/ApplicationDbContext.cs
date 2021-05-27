using Microsoft.EntityFrameworkCore;
using PF_Project_CORE.Entities;
using PF_Project_CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_Project_CORE.Database
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var LOCAL_DB = true;

            if (LOCAL_DB)
            {
                // Run Migration Commands
                // -------------------------
                // - add-migration fundraisingAppCore
                // - update-database
                optionsBuilder.UseSqlServer("Data Source = localhost; Initial Catalog= Fundraising.App; Integrated Security = true");

            }
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }


    }
}
