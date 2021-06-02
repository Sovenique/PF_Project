using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_Project_CORE.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal AmountGathered { get; set; }
        public decimal TargetAmount { get; set; }


        // <Foreign Key> : Link to <Member> entity
        public Member Creator { get; set; }
        public string CreatorId { get; set; }
        public List<Package> Packages { get; set; }
    }
}
