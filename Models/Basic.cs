using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProperty.Models
{
    public class Basic
    {
        [Key]
        public int BasicId { get; set; }
        public string Name { get; set; }
        public virtual List<BasicProperties> BasicProperties { get; set; }
        public Basic()
        {
            BasicProperties = new List<BasicProperties>();
        }
    }
    public class BasicProperties
    {
        public int BasicId { get; set; }
        public Basic Basic { get; set; }
        public int PropertiesId { get; set; }
        public Properties Properties { get; set; }
    }
}
