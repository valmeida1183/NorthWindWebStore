using Microsoft.Extensions.DependencyInjection;
using NorthWind.Application.Interfaces;
using NorthWind.Application.Services;
using NorthWind.Domain.Interfaces.Repository;
using NorthWind.Domain.Interfaces.Service;
using NorthWind.Domain.Services;
using NorthWind.Infra.Data.Repository;

namespace NorthWind.Infra.CrossCuting.IoC
{
    public class BootStrapper
    {        
        public static void RegisterServices(IServiceCollection services)
        {
            // Registra todas as injeções de dependência do projeto em um módulo separado.

            // App
            services.AddTransient<ICategoryAppService, CategoryAppService>();
            // Domain
            services.AddTransient<ICategoryService, CategoryService>();
            // Infra Dados
            services.AddTransient<ICategoryRepository, CategoryRepository>();
        }
    }
}
