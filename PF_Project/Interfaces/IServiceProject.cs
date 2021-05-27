using PF_Project_CORE.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_Project_CORE.Interfaces
{
    public interface IServiceProject
    {
        // CREATE
        public OptionsProject CreateProject(OptionsProject optionProjrct);
        // READ
        public List<OptionsProject> GetAllProjects();
        public OptionsProject GetProjectById(int Id);
        // UPDATE
        public OptionsProject UpdateProject(OptionsProject optionsProject, int Id);
        // DELETE
        public bool DeleteProject(int Id);
    }
}
