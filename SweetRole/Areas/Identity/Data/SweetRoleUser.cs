﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SweetRole.Models;

namespace SweetRole.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the SweetRoleUser class
    public class SweetRoleUser : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }
        [PersonalData]
        public DateTime DOB { get; set; }

        public virtual ICollection<Character> Characters { get; set; }
    }
}
