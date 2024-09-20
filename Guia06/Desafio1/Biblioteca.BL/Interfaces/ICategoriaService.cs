using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entities.DTO;
using Biblioteca.Entities.Models;

namespace Biblioteca.BL.Interfaces
{
    public interface ICategoriaService
    {
        public Task<List<CategoríasDto>> GetCategoriasAsync();
        public Task<CategoríasDto> GetCategoriaByIdAsync(int id);
        public Task<int> InsertCategoriaAsync(CategoríasDto categoria);
        public Task<CategoríasDto> UpdateCategoriaAsync(CategoríasDto categoria);
        public Task<bool> DeleteCategoriaAsync(int id);
    }
}
