using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace WebApplicationProperty.Models
{
    public class ApplicationUser : IdentityUser<string>
    {
        public ApplicationUser() { }
        public ApplicationUser(string name) : base(name) { }
    }

    public class ApplicationRole : IdentityRole<string>
    {
        public ApplicationRole() { }
        public ApplicationRole(string name) : base(name) { }
    }
}