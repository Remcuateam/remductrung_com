using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using AspNetMvc.Services.AutoMapper;

namespace AspNetMvc.Services.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.ValidateInlineMaps = false;
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}
