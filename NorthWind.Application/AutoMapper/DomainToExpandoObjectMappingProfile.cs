using AutoMapper;
using NorthWind.Domain.Entities;
using System.Dynamic;

namespace NorthWind.Application.AutoMapper
{
    public class DomainToExpandoObjectMappingProfile : Profile
    {
        public DomainToExpandoObjectMappingProfile()
        {
            CreateMap<Category, DynamicObject>();           
        }
    }
}
