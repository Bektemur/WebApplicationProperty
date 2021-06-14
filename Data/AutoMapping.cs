using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationProperty.Models;
using WebApplicationProperty.ViewModel.Properties;

namespace WebApplicationProperty.Data
{
    public class AutoMapping : Profile
    {
        public AutoMapping() 
        {
            CreateMap<PropertyViewModel, Property>();
            CreateMap<Property, PropertyViewModel>();
        }
    }
}
