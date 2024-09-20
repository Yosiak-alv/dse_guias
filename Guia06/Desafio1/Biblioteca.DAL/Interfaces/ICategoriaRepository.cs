using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entities.Models;

namespace Biblioteca.DAL.Interfaces
{
    public interface ICategoriaRepository
    {
        public Task<List<Categorías>> GetCategoriasAsync();
        public Task<Categorías> GetCategoriaByIdAsync(int id);
        public Task<int> InsertCategoriaAsync(Categorías categoria);
        public Task<Categorías> UpdateCategoriaAsync(Categorías categoria);
        public Task<bool> DeleteCategoriaAsync(int id);
    }
}
