using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace WebApplicationProperty.Data
{
    public class ApplicationUser : IdentityUser<string>
    {
        public ApplicationUser() { }
        public ApplicationUser(string name) : base(name) { }
        public DateTime CreatedDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class ApplicationRole : IdentityRole<string>
    {
        public ApplicationRole() { }
        public ApplicationRole(string name) : base(name) { }

        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
    }
}