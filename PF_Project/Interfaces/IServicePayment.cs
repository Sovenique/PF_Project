using PF_Project_CORE.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_Project_CORE.Interfaces
{
    public interface IServicePayment
    {
        // CREATE
        public OptionPayment CreatePayment(OptionPayment optionPayment,OptionMember optionMember,OptionPackage optionPackage);
        // READ ALL
        public List<OptionPayment> GetAllPayment();
        // READ BY ID
        public OptionPayment GetPaymentById(int Id);
        // UPDATE
        public OptionPayment UpdatePackage(OptionPayment optionPayment, int Id);
        // DELETE
        public bool DeletePayment(int Id);
    }
}
