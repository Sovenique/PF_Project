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
    public class ServiceMember : IServiceMember
    {
        private readonly IApplicationDbContext _dbContext;


        public ServiceMember(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // CREATE
        // --------------------------------------------------------
        public OptionMember CreateMember(OptionMember optionMember)
        {
            Member member = new()
            {
                FirstName = optionMember.FirstName,
                LastName = optionMember.LastName,
                Address = optionMember.Address,
                Email = optionMember.Email,
                Phone = optionMember.Phone,
                Birthday = optionMember.Birthday,
                CreatedDate = DateTime.Now,
                Projects = null
            };

            _dbContext.Members.Add(member);
            _dbContext.SaveChanges();

            return new OptionMember(member);

        }

        // DELETE
        // --------------------------------------------------------
        public bool DeleteMember(int Id)
        {
            Member dbContextMember = _dbContext.Members.Find(Id);

            if (dbContextMember == null) return false;

            _dbContext.Members.Remove(dbContextMember);
            _dbContext.SaveChanges();
            return true;
        }

        // READ / ALL
        // --------------------------------------------------------
        public List<OptionMember> GetAllMembers()
        {
            List<Member> members = _dbContext.Members.ToList();
            List<OptionMember> optionMembers = new();
            members.ForEach(member => optionMembers.Add(new OptionMember(member)));
            return optionMembers;
        }

        // READ / BY ID
        // --------------------------------------------------------
        public OptionMember GetMemberById(string Id)
        {
            Member member = _dbContext.Members.Find(Id);
            if (member == null)
            {
                return null;
            }
            return new OptionMember(member);
        }

        // UPDATE
        // --------------------------------------------------------
        public OptionMember UpdateMember(OptionMember optionMember, int Id)
        {
            Member dbContextMember = _dbContext.Members.Find(Id);
            if (dbContextMember == null) return null;

            // Update all members even if some of them are not changed
            dbContextMember.FirstName = optionMember.FirstName;
            dbContextMember.LastName = optionMember.LastName;
            dbContextMember.Address = optionMember.Address;
            dbContextMember.Email = optionMember.Email;
            dbContextMember.Phone = optionMember.Phone;
            dbContextMember.Birthday = optionMember.Birthday;
            dbContextMember.Projects = optionMember.Projects;

            _dbContext.SaveChanges();
            return new OptionMember(dbContextMember);
        }
    }
}
