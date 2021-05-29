using PF_Project_CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_Project_CORE.Options
{
    public class OptionPayment
    {
        public int Id { get; set; }
        public Package Package { get; set; }
        public int? PackageId { get; set; }
        public Member Member { get; set; }
        public int? MemberId { get; set; }
        public OptionPayment() { }

        public OptionPayment(Payment Payment) 
        {
            Id = Payment.Id;
            Package = Payment.Package;
            PackageId = Payment.PackageId;
            Member = Payment.Member;
            MemberId = Payment.MemberId;
        }
    }
}
