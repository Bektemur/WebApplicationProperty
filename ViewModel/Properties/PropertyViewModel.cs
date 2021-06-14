using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationProperty.Models;

namespace WebApplicationProperty.ViewModel.Properties
{
    public class PropertyViewModel : Property
    {
        public string[] SelectedBasic { get; set; }
    }
}
