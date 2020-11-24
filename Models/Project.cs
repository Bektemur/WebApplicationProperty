using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationProperty.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public List<Properties> Properties { get; set; }
    }
}