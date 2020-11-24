using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace WebApplicationProperty.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int ApplicationUserId { get; set; }
    }
}