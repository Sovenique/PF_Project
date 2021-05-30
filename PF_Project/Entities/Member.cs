using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace PF_Project_CORE.Entities
{
    public class Member : IdentityUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Project> Projects { get; set; }
        public List<Payment> Payments { get; set; }
    }
}
