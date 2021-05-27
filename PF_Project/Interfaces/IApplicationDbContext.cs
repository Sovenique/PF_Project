using Microsoft.EntityFrameworkCore;
using PF_Project_CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_Project_CORE.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Project> Projects { get; set; }
        public int SaveChanges();
    }
}
