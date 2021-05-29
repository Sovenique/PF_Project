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
    public class ServicePackage : IServicePackage
    {
        private readonly IApplicationDbContext _dbContext;

        public ServicePackage(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // CREATE
        // --------------------------------------------------------
        public OptionPackage CreatePackage(OptionPackage optionPackage,OptionProject optionProject)
        {
            // FIND THE CORRESPONDING PROJECT
            var project = _dbContext.Projects.Where(pro => pro.Id == optionProject.Id).ToList();

            Package package = new()
            {
                Title = optionPackage.Title,
                Description = optionPackage.Description,
                Value = optionPackage.Value,
                Project = project[0]

            };

            _dbContext.Packages.Add(package);
            _dbContext.SaveChanges();

            return new OptionPackage(package);
        }

        // DELETE
        // --------------------------------------------------------
        public bool DeletePackage(int Id)
        {
            Package dbContextPackage = _dbContext.Packages.Find(Id);

            if (dbContextPackage == null) return false;

            _dbContext.Packages.Remove(dbContextPackage);
            _dbContext.SaveChanges();
            return true;
        }

        // READ / ALL
        // --------------------------------------------------------
        public List<OptionPackage> GetAllPackages()
        {
            List<Package> packages = _dbContext.Packages.ToList();
            List<OptionPackage> optionPackage = new();
            packages.ForEach(package => optionPackage.Add(new OptionPackage(package)));
            return optionPackage;
        }

        // READ / BY ID
        // --------------------------------------------------------
        public OptionPackage GetPackageById(int Id)
        {
            Package package = _dbContext.Packages.Find(Id);
            if (package == null)
            {
                return null;
            }
            return new OptionPackage(package);
        }

        // UPDATE
        // --------------------------------------------------------
        public OptionPackage UpdatePackage(OptionPackage optionPackage, int Id)
        {
            Package dbContextPackage = _dbContext.Packages.Find(Id);
            if (dbContextPackage == null) return null;

            dbContextPackage.Title = optionPackage.Title;
            dbContextPackage.Description = optionPackage.Description;
            dbContextPackage.Value = optionPackage.Value;
            dbContextPackage.Project = optionPackage.Project;

            _dbContext.SaveChanges();
            return new OptionPackage(dbContextPackage);

        }
    }
}
