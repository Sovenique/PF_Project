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
        public OptionProject CreateProject(OptionProject optionProject);
        // READ ALL
        public List<OptionProject> GetAllProjects();
        // READ BY ID
        public OptionProject GetProjectById(int Id);
        // UPDATE
        public OptionProject UpdateProject(OptionProject optionsProject, int Id);
        // DELETE
        public bool DeleteProject(int Id);
    }
}
