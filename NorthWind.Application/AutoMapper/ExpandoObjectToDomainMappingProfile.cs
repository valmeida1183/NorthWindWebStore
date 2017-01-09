using AutoMapper;
using NorthWind.Domain.Entities;
using System.Dynamic;

namespace NorthWind.Application.AutoMapper
{
    public class ExpandoObjectToDomainMappingProfile : Profile
    {
        public ExpandoObjectToDomainMappingProfile()
        {
            CreateMap<ExpandoObject, Category>();
        }
    }
}
