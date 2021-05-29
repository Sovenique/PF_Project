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
    public class ServiceProject : IServiceProject
    {
        private readonly IApplicationDbContext _dbContext;

        public ServiceProject(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // CREATE
        // --------------------------------------------------------
        public OptionProject CreateProject(OptionProject optionProject, OptionMember optionMember)
        {
            // FIND THE MEMBER CREATOR (BY EMAIL)
            var member = _dbContext.Members.Where(mem => mem.Email == optionMember.Email).ToList();

            // CREATE THE MEMBER OBJECT
            Project project = new()
            {
                Title = optionProject.Title,
                Description = optionProject.Description,
                CreatedDate = DateTime.Now,
                AmountGathered = 0,
                TargetAmount = optionProject.TargetAmount,
                Creator = member[0]
            };

            _dbContext.Projects.Add(project);
            _dbContext.SaveChanges();

            return new OptionProject(project);
        }

        // DELETE
        // --------------------------------------------------------
        public bool DeleteProject(int Id)
        {
            Project dbContextProject = _dbContext.Projects.Find(Id);
            if (dbContextProject == null) return false;
            _dbContext.Projects.Remove(dbContextProject);
            _dbContext.SaveChanges();
            return true;

        }

        // READ / ALL
        // --------------------------------------------------------
        public List<OptionProject> GetAllProjects()
        {
            List<Project> projects = _dbContext.Projects.ToList();
            List<OptionProject> optionsProject = new();
            projects.ForEach(project => optionsProject.Add(new OptionProject(project)));
            return optionsProject;
        }

        // READ / BY ID
        // --------------------------------------------------------
        public OptionProject GetProjectById(int Id)
        {
            Project project = _dbContext.Projects.Find(Id);
            if (project == null)
            {
                return null;
            }
            return new OptionProject(project);
        }

        // UPDATE
        // --------------------------------------------------------
        public OptionProject UpdateProject(OptionProject optionsProject, int Id)
        {
            Project dbContextProject = _dbContext.Projects.Find(Id);
            if (dbContextProject == null) return null;

            dbContextProject.Title = optionsProject.Title;
            dbContextProject.Description = optionsProject.Description;
            dbContextProject.AmountGathered = optionsProject.AmountGathered;
            dbContextProject.TargetAmount = optionsProject.TargetAmount;
            dbContextProject.Creator = optionsProject.Creator;


            _dbContext.SaveChanges();
            return new OptionProject(dbContextProject);

        }
    }
}
