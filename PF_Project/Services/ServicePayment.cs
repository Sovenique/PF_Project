using PF_Project_CORE.Entities;
using PF_Project_CORE.Interfaces;
using PF_Project_CORE.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_Project_CORE.Services
{
    public class ServicePayment : IServicePayment
    {
        private readonly IApplicationDbContext _dbContext;

        public ServicePayment(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // CREATE
        // --------------------------------------------------------
        public OptionPayment CreatePayment(OptionPayment optionPayment,OptionMember optionMember,OptionPackage optionPackage)
        {
            Payment payment = new()
            {
                Package = optionPayment.Package,
                Member = optionPayment.Member
            };

            _dbContext.Payments.Add(payment);
            _dbContext.SaveChanges();

            return new OptionPayment(payment);
        }

        // DELETE
        // --------------------------------------------------------
        public bool DeletePayment(int Id)
        {
            Payment dbContextPayment = _dbContext.Payments.Find(Id);

            if (dbContextPayment == null) return false;

            _dbContext.Payments.Remove(dbContextPayment);
            _dbContext.SaveChanges();
            return true;
        }

        // READ / ALL
        // --------------------------------------------------------
        public List<OptionPayment> GetAllPayment()
        {
            List<Payment> payments = _dbContext.Payments.ToList();
            List<OptionPayment> optionPayment = new();
            payments.ForEach(payment => optionPayment.Add(new OptionPayment(payment)));
            return optionPayment;
        }

        // READ / BY ID
        // --------------------------------------------------------
        public OptionPayment GetPaymentById(int Id)
        {
            Payment payment = _dbContext.Payments.Find(Id);
            if (payment == null)
            {
                return null;
            }
            return new OptionPayment(payment);
        }

        // UPDATE
        // --------------------------------------------------------
        public OptionPayment UpdatePackage(OptionPayment optionPayment, int Id)
        {
            Payment dbContextPayment = _dbContext.Payments.Find(Id);
            if (dbContextPayment == null) return null;

            // Update all members even if some of them are not changed
            dbContextPayment.Member = optionPayment.Member;
            dbContextPayment.Package = optionPayment.Package;

            _dbContext.SaveChanges();
            return new OptionPayment(dbContextPayment);
        }
    }
}
