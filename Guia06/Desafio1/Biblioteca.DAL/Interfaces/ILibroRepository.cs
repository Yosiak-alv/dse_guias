using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entities.Models;

namespace Biblioteca.DAL.Interfaces
{
    public interface ILibroRepository
    {
        public Task<List<Libro>> GetLibrosAsync();
        public Task<Libro> GetLibroByIdAsync(int id);
        public Task<int> InsertLibroAsync(Libro libro);
        public Task<Libro> UpdateLibroAsync(Libro libro);
        public Task<bool> DeleteLibroAsync(int id);
    }
}
