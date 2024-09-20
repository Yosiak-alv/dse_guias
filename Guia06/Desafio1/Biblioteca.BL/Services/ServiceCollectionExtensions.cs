using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DAL.Interfaces;
using Biblioteca.DAL;
using Microsoft.Extensions.DependencyInjection;
using Biblioteca.BL.AutoMapper;
using Biblioteca.BL.Interfaces;
using Biblioteca.DAL.Services;

namespace Biblioteca.BL.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceConnector(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutomapperProfile).Assembly);
            services.AddTransient<IAutorService, AutorService>();
            services.AddTransient<ICategoriaService, CategoriaService>();
            services.AddTransient<ILibroService, LibroService>();
            services.AddRepositoryConnector();
            return services;
        }

    }
}
