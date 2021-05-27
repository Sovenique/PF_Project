﻿using PF_Project_CORE.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_Project_CORE.Interfaces
{
    interface IServiceMember
    {
        // CREATE
        public OptionMember CreateMember(OptionMember optionMember);
        // READ
        public List<OptionMember> ReadAllMembers();
        public OptionMember GetMemberById(int Id);
        // UPDATE
        public OptionMember UpdateMember(OptionMember optionMember, int Id);
        // DELETE
        public bool DeleteMember(int Id);
    }
}
