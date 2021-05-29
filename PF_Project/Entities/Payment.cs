using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_Project_CORE.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public virtual Package Package { get; set; }
        public int? PackageId { get; set; }
        public virtual Member Member { get; set; }
        public int? MemberId { get; set; }
    }
}
