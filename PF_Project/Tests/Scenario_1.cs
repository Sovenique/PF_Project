using PF_Project_CORE.Database;
using PF_Project_CORE.Entities;
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

            optionMembers = serviceMember.GetAllMembers();
            optionMembers.ForEach(member => 
                Console.WriteLine($"\tName:{member.FirstName} , Email:{member.Email}")
            );

            return true;
        }

        public static bool test_delete_members()
        {

            IApplicationDbContext db = new ApplicationDbContext();
            ServiceMember serviceMember = new(db);

            List<OptionMember> optionMembers = new();
            
            // READ ALL MEMBERS
            optionMembers = serviceMember.GetAllMembers();

            // DELETE ALL MEMBERS
            optionMembers.ForEach(member => 
                serviceMember.DeleteMember(member.Id)
            );

            return true;
        }


        public static bool test_create_projects()
        {

            IApplicationDbContext db = new ApplicationDbContext();
            ServiceProject serviceProject = new(db);
            ServiceMember serviceMember = new(db);

            // READ ALL MEMBERS
            List<OptionMember> optionMembers = new();
            
            optionMembers = serviceMember.GetAllMembers();


            List<OptionProject> optionsProjects = new()
            {

                new OptionProject
                {
                    Title = "Computer Store",
                    Description = "A new type of store for computer parts",
                    CreatedDate = DateTime.Now,
                    AmountGathered = 0,
                    TargetAmount = 5000
                },
                new OptionProject
                {
                    Title = "WebSite Builder",
                    Description = "Build your own website easy and fast",
                    CreatedDate = DateTime.Now,
                    AmountGathered = 0,
                    TargetAmount = 12000
                }
            };

            optionsProjects.ForEach(project => serviceProject.CreateProject(project,optionMembers[0]));
            
            return true;
        }

        public static bool test_delete_projects()
        {
            IApplicationDbContext db = new ApplicationDbContext();
            ServiceProject serviceProject = new(db);

            List<OptionProject> optionProject = new();

            // READ ALL MEMBERS
            optionProject = serviceProject.GetAllProjects();

            // DELETE ALL MEMBERS
            optionProject.ForEach(project =>
                serviceProject.DeleteProject(project.Id)
            );

            return true;
        }

        public static bool execute()
        {
            Console.WriteLine("> Running Scenario [1]...");
            Console.WriteLine("> Running Scenario [1]... delete all projects");
            test_delete_projects();
            Console.WriteLine("> Running Scenario [1]... delete all members");
            test_delete_members();
            Console.WriteLine("> Running Scenario [1]... create members");
            test_create_memeber();
            Console.WriteLine("> Running Scenario [1]... read all members");
            test_read_members();
            Console.WriteLine("> Running Scenario [1]... create a project for member with ID = [0]");
            test_create_projects();

            return true;
        }


    }
}
