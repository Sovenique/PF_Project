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
        public Package Package { get; set; }
        public Member Member { get; set; }
    }
}
