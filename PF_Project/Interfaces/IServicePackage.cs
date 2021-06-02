using PF_Project_CORE.Options;
using System.Collections.Generic;

namespace PF_Project_CORE.Interfaces
{
    public interface IServicePackage
    {
        // CREATE
        public OptionPackage CreatePackage(OptionPackage optionPackage);
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
