using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NorthWind.Application.Interfaces;
using NorthWind.Application.Services;
using NorthWind.Domain.Interfaces.Repository;
using NorthWind.Domain.Interfaces.Service;
using NorthWind.Domain.Services;
using NorthWind.Infra.Data.Interface;
using NorthWind.Infra.Data.Repository;
using NorthWind.Infra.Data.UoW;

namespace NorthWind.Infra.CrossCuting.IoC
{
    public class BootStrapper
    {        
        public static void RegisterServices(IServiceCollection services, string connectionString)
        {
            // Registra todas as injeções de dependência do projeto em um módulo separado.

            // Add framework services.
            services.AddDbContext<NorthWindContext>(options =>
            options.UseSqlServer(connectionString));            

            // App
            services.AddScoped<ICategoryAppService, CategoryAppService>();
            // Domain
            services.AddScoped<ICategoryService, CategoryService>();
            // Infra Dados
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }       
    }
}
