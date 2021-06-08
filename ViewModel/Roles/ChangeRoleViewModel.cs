﻿using WebApplicationProperty.Data;
using System.Collections.Generic;

namespace WebApplicationProperty.Models
{
    public class ChangeRoleViewModel
    {
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public List<ApplicationRole> AllRoles { get; set; }
        public IList<string> UserRoles { get; set; }
        public ChangeRoleViewModel()
        {
            AllRoles = new List<ApplicationRole>();
            UserRoles = new List<string>();
        }
    }
}
