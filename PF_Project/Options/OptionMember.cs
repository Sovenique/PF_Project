using PF_Project_CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_Project_CORE.Options
{
    public class OptionMember
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Project> Projects { get; set; }

        public OptionMember() { }
        public OptionMember(Member Member)
        {
            if (Member != null)
            {
                Id = Member.Id;
                FirstName = Member.FirstName;
                LastName = Member.LastName;
                Address = Member.Address;
                Email = Member.Email;
                Phone = Member.Phone;
                Birthday = Member.Birthday;
                CreatedDate = Member.CreatedDate;
                Projects = Member.Projects;
            }

        }
    }
}
