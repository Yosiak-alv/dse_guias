using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entities.DTO;
using Biblioteca.Entities.Models;

namespace Biblioteca.BL.Interfaces
{
    public interface ILibroService
    {
        public Task<List<LibroDto>> GetLibrosAsync();
        public Task<Libro> GetLibroByIdAsync(int id);
        public Task<int> InsertLibroAsync(Libro libro);
        public Task<Libro> UpdateLibroAsync(Libro libro);
        public Task<bool> DeleteLibroAsync(int id);
    }
}
