using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg => {
                cfg.AddProfile<DomainToExpandoObjectMappingProfile>();
                cfg.AddProfile<ExpandoObjectToDomainMappingProfile>();
            });
        }
    }
}
