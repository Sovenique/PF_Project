using PF_Project_CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_Project_CORE.Options
{
    public class OptionPackage
    {
        public int Id { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public decimal Value { get; set; }
        public Project Project { get; set; }

        public OptionPackage() { }
        public OptionPackage(Package package )
        {
            Id = package.Id;
            Title = package.Title;
            Description = package.Description;
            Value = package.Value;
            Project = package.Project;
        }
    }
}
