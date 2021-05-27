using PF_Project_CORE.Entities;
using PF_Project_CORE.Interfaces;
using PF_Project_CORE.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_Project_CORE.Services
{
    public class ServiceProject
    {
        private readonly IApplicationDbContext dbContext;

        public ServiceProject(IApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        // CREATE
        // --------------------------------------------------------
        public OptionsProject CreateProject(OptionsProject optionProject)
        {
            Project project = new()
            {
                Title = optionProject.Title,
                Description = optionProject.Description,
                CreatedDate = DateTime.Now,
                AmountGathered = 0,
                TargetAmount = optionProject.TargetAmount,
                Creator = optionProject.Creator
            };
            
            dbContext.Projects.Add(project);
            dbContext.SaveChanges();

            return new OptionsProject(project);
        }

        // DELETE
        // --------------------------------------------------------
        public bool DeleteProject(int Id)
        {
            Project dbContextProject = dbContext.Projects.Find(Id);
            if (dbContextProject == null) return false;
            dbContext.Projects.Remove(dbContextProject);
            return true;

        }

        // READ / ALL
        // --------------------------------------------------------
        public List<OptionsProject> GetAllProjects()
        {
            List<Project> projects = dbContext.Projects.ToList();
            List<OptionsProject> optionsProject = new();
            projects.ForEach(project => optionsProject.Add(new OptionsProject(project)));
            return optionsProject;
        }

        // READ / BY ID
        // --------------------------------------------------------
        public OptionsProject GetProjectById(int Id)
        {
            Project project = dbContext.Projects.Find(Id);
            if (project == null)
            {
                return null;
            }
            return new OptionsProject(project);
        }

        // UPDATE
        // --------------------------------------------------------
        public OptionsProject UpdateProject(OptionsProject optionsProject, int Id)
        {
            Project dbContextProject = dbContext.Projects.Find(Id);
            if (dbContextProject == null) return null;

            dbContextProject.Title = optionsProject.Title;
            dbContextProject.Description = optionsProject.Description;
            dbContextProject.AmountGathered = optionsProject.AmountGathered;
            dbContextProject.TargetAmount = optionsProject.TargetAmount;
            dbContextProject.Creator = optionsProject.Creator;


            dbContext.SaveChanges();
            return new OptionsProject(dbContextProject);

        }
    }
}
