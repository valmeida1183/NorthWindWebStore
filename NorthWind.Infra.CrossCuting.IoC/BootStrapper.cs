using Infra.Data.Context;
using Microsoft.Extensions.DependencyInjection;
using NorthWind.Domain.Interfaces.Repository;
using NorthWind.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.Infra.CrossCuting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Registra todas as injeções de dependência do projeto em um módulo separado.

            // App

            // Domain
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            // Infra Dados
        }
    }
}
