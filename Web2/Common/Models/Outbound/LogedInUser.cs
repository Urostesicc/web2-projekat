﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Outbound
{
    public class LogedInUser
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Adress { get; set; }
        public string UserType { get; set; }
        public string ProfilePicture { get; set; }
        public string Verified { get; set; }
    }
}
