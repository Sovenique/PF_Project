using PF_Project_CORE.Database;
using PF_Project_CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_Project_CORE.Tests
{
    public static class Scenario_2
    {
        public static bool test_get_projects()
        {
            IApplicationDbContext db = new ApplicationDbContext();

            var AllProjects = db.Projects.ToList();

            AllProjects.ForEach(project =>
                Console.WriteLine($"{project.Id} , {project.Title} , {project.Creator}")
            );

            return true;
        }
    }
}
