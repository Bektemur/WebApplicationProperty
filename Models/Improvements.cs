﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationProperty.Models
{
    public class Improvement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ImprovementType Type { get; set; }
        [Required]
        public string Name { get; set; }
    }

    public class ImprovementToProperty 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int PropertyId { get; set; }
        [ForeignKey("PropertyId")]
        public Property Property { get; set; }

        public int ImprovementId { get; set; }
        [ForeignKey("ImprovementId")]
        public Improvement Improvement { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }

    public enum ImprovementType
    {
        None = 0,
        Basic = 1,
        Facilities = 2,
        Interior = 3,
        Fixtures = 4,
        CommonArea = 5,
        Extra = 6,
        Other = 7,
    }
}
