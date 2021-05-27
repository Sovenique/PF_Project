using PF_Project_CORE.Database;
using PF_Project_CORE.Interfaces;
using PF_Project_CORE.Options;
using PF_Project_CORE.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_Project_CORE.Tests
{
    public static class Scenario_1
    {



        public static bool test_create_memeber()
        {
            IApplicationDbContext db = new ApplicationDbContext();
            ServiceMember serviceMember = new(db);

            List<OptionMember> optionMembers = new()
            {
                new OptionMember
                {
                    FirstName = "Nikos",
                    LastName = "Kyriakoulhs",
                    Address = "Athens 156",
                    Email = "nikolas@gmail.com",
                    Phone = "6953772653",
                    Birthday = DateTime.Parse("07/12/1995"),
                    CreatedDate = DateTime.Now
                },
                new OptionMember
                {
                    FirstName = "Kwstas",
                    LastName = "Vasilas",
                    Address = "Agia Triada 12",
                    Email = "vasilas@gmail.com",
                    Phone = "6959595945",
                    Birthday = DateTime.Parse("11/25/1994"),
                    CreatedDate = DateTime.Now
                },
                new OptionMember
                {
                    FirstName = "George",
                    LastName = "Kapatos",
                    Address = "Kerkiras 5-A",
                    Email = "g.kapatoss@yahoo.com",
                    Phone = "6912341234",
                    Birthday = DateTime.Parse("01/17/2000"),
                    CreatedDate = DateTime.Now
                },
            };

            optionMembers.ForEach(member => serviceMember.CreateMember(member));


            return true;
        }

        public static bool test_read_members()
        {
            IApplicationDbContext db = new ApplicationDbContext();
            ServiceMember serviceMember = new(db);

            List<OptionMember> optionMembers = new();

            optionMembers = serviceMember.ReadAllMembers();
            optionMembers.ForEach(member => 
                Console.WriteLine($"Name:{member.FirstName} , Email:{member.Email}")
            );

            return true;
        }

        public static bool test_delete_members()
        {

            IApplicationDbContext db = new ApplicationDbContext();
            ServiceMember serviceMember = new(db);

            List<OptionMember> optionMembers = new();
            
            // READ ALL MEMBERS
            optionMembers = serviceMember.ReadAllMembers();

            // DELETE ALL MEMBERS
            optionMembers.ForEach(member => 
                serviceMember.DeleteMember(member.Id)
            );

            return true;
        }


        public static bool execute()
        {
            Console.WriteLine("> Running Scenario [1]...");
            test_delete_members();
            test_create_memeber();
            test_read_members();


            return true;
        }

    }
}
