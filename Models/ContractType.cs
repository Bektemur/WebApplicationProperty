using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProperty.Models
{
    public class ContractType
    {
        [Key]
        public int ContractTypeId { get; set; }
        public string Name { get; set; }
        public List<Property> Properties { get; set; }
    }
}
