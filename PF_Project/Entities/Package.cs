using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_Project_CORE.Entities
{
    public class Package
    {
        public int Id { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public decimal Value { get; set; }
        public Project Project { get; set; }
    }
}
