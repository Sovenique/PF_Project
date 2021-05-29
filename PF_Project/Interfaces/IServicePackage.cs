using PF_Project_CORE.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_Project_CORE.Interfaces
{
    public interface IServicePackage
    {
        // CREATE
        public OptionPackage CreatePackage(OptionPackage optionPackage,OptionProject optionProject);
        // READ ALL
        public List<OptionPackage> GetAllPackages();
        // READ BY ID
        public OptionPackage GetPackageById(int Id);
        // UPDATE
        public OptionPackage UpdatePackage(OptionPackage optionPackage, int Id);
        // DELETE
        public bool DeletePackage(int Id);
    }
}
