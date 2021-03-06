﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationProperty.Models;

namespace WebApplicationProperty.ViewModel
{
    public class ImprovmentsViewModel
    {
        public int ImprovementId { get; set; }
        public string Name { get; set; }
        public ImprovementType Type { get; set; }
        public bool Assigned { get; set; }
    }
}
