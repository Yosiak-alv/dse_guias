using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.DAL.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositoryConnector(this IServiceCollection services)
        {
            services.AddTransient<IDatabaseRepository, DatabaseRepository>();
            services.AddTransient<IAutorRepository, AutorRepository>();
            services.AddTransient<ICategoriaRepository, CategoriasRepository>();
            services.AddTransient<ILibroRepository, LibroRepository>();
            //services.AddTransient<IEditorialRepository, EditorialRepository>();
            return services;
        }

    }
}
