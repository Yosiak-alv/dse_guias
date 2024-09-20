using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Biblioteca.BL.Interfaces;
using Biblioteca.DAL;
using Biblioteca.DAL.Interfaces;
using Biblioteca.Entities.DTO;
using Biblioteca.Entities.Models;

namespace Biblioteca.BL
{
    public class LibroService : ILibroService
    {
        private readonly ILibroRepository repository;
        private readonly IAutorRepository autorRepository;
        private readonly ICategoriaRepository categoriaRepository;
        private readonly IMapper mapper;

        public LibroService(ILibroRepository repository, IAutorRepository autorRepository, ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            this.repository = repository;
            this.autorRepository = autorRepository;
            this.categoriaRepository = categoriaRepository;
            this.mapper = mapper;
        }

        public async Task<List<LibroDto>> GetLibrosAsync()
        {
            try
            {
                var libros = await repository.GetLibrosAsync();

                var autores = await autorRepository.GetAutoresAsync();
                var categorias = await categoriaRepository.GetCategoriasAsync();

                var result = libros.Select(libro =>
                {
                    var dto = mapper.Map<Libro, LibroDto>(libro);
                    dto.NombreAutor = autores.FirstOrDefault(a => a.id == libro.AutorID)?.apellido;
                    dto.NombreCategoria = categorias.FirstOrDefault(c => c.id == libro.CategoriaID)?.nombre;
                    return dto;
                }).ToList();

                return result;
            }
            catch (Exception ex)
            {
                return new List<LibroDto>();
            }
        }

        public async Task<Libro> GetLibroByIdAsync(int id)
        {
            try
            {
                //var result = await repository.GetLibroByIdAsync(id);
                //return mapper.Map<Libro, LibroDto>(result);
                return await repository.GetLibroByIdAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> InsertLibroAsync(Libro libro)
        {
            try
            {
                //var model = mapper.Map<LibroDto, Libro>(libro);
                return await repository.InsertLibroAsync(libro);
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<Libro> UpdateLibroAsync(Libro libro)
        {
            try
            {
                var model = mapper.Map<Libro, Libro>(libro);
                var result = await repository.UpdateLibroAsync(model);
                return mapper.Map<Libro, Libro>(result);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> DeleteLibroAsync(int id)
        {
            try
            {
                return await repository.DeleteLibroAsync(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
