using AutoMapper;
using Biblioteca.Entities.DTO;
using Biblioteca.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BL.AutoMapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            /*CreateMap<Editorial, EditorialDto>()
                .ForMember(destination => destination.Codigo, options => options.MapFrom(source => source.id))
                .ForMember(destination => destination.NombreEditorial, options => options.MapFrom(source => source.nombre))
                .ReverseMap();*/
            CreateMap<Autor, AutorDto>()
                .ForMember(destination => destination.Codigo, options => options.MapFrom(source => source.id))
                .ForMember(destination => destination.NombreAutor, options => options.MapFrom(source => source.nombre))
                .ForMember(destination => destination.ApellidoAutor, options => options.MapFrom(source => source.apellido))
                .ReverseMap();

            CreateMap<Categorías, CategoríasDto>()
                 .ForMember(destination => destination.Codigo, options => options.MapFrom(source => source.id))
                 .ForMember(destination => destination.NombreCategoria, options => options.MapFrom(source => source.nombre))
                 .ReverseMap();

            CreateMap<Libro, LibroDto>()
                 .ForMember(destination => destination.Codigo, options => options.MapFrom(source => source.id))
                 .ForMember(destination => destination.Titulo, options => options.MapFrom(source => source.Titulo))
                 .ForMember(destination => destination.FechaPublicacion, options => options.MapFrom(source => source.FechaPublicacion))
                 .ForMember(destination => destination.AutorID, options => options.MapFrom(source => source.AutorID))
                 .ForMember(destination => destination.CategoriaID, options => options.MapFrom(source => source.CategoriaID))
                 .ReverseMap();

        }

    }
}
