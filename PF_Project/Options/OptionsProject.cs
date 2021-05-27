using PF_Project_CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_Project_CORE.Options
{
    public class OptionsProject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal AmountGathered { get; set; }
        public decimal TargetAmount { get; set; }
        public Member Creator { get; set; }


        public OptionsProject() { }
        public OptionsProject(Project project)
        {
            if (project != null)
            {
                Title = project.Title;
                Description = project.Description;
                CreatedDate = project.CreatedDate;
                AmountGathered = project.AmountGathered;
                TargetAmount = project.TargetAmount;
                Creator = project.Creator;
            }
        }
    }
}
