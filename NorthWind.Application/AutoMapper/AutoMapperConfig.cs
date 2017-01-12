using AutoMapper;

namespace NorthWind.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<DomainToExpandoObjectMappingProfile>();
                cfg.AddProfile<ExpandoObjectToDomainMappingProfile>();
            });

            //Mapper.Initialize(cfg => { });
        }
    }
}
