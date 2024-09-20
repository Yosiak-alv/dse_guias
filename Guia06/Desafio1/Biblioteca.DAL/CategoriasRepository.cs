using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DAL.Interfaces;
using Biblioteca.Entities.Models;
using Dapper;

namespace Biblioteca.DAL
{
    public class CategoriasRepository : ICategoriaRepository
    {
        private readonly IDatabaseRepository databaseRepository;

        public CategoriasRepository(IDatabaseRepository databaseRepository)
        {
            this.databaseRepository = databaseRepository;
        }

        public async Task<List<Categorías>> GetCategoriasAsync()
        {
            string query = "SELECT CategoriaID AS id, nombre FROM Categorías";
            return await databaseRepository.GetDataByQueryAsync<Categorías>(query);
        }

        public async Task<Categorías> GetCategoriaByIdAsync(int id)
        {
            string query = "SELECT CategoriaID AS id, nombre FROM Categorías WHERE CategoriaID = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            return (await databaseRepository.GetDataByQueryAsync<Categorías>(query, parameters)).FirstOrDefault();
        }

        public async Task<int> InsertCategoriaAsync(Categorías categoria)
        {
            string query = "INSERT INTO Categorías (nombre) VALUES (@nombre); SELECT SCOPE_IDENTITY()";
            var parameters = new DynamicParameters();
            parameters.Add("@nombre", categoria.nombre);
            return await databaseRepository.InsertAsync(query, parameters);
        }

        public async Task<Categorías> UpdateCategoriaAsync(Categorías categoria)
        {
            string query = "UPDATE Categorías SET nombre = @nombre WHERE CategoriaID = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", categoria.id);
            parameters.Add("@nombre", categoria.nombre);
            await databaseRepository.UpdateAsync<Categorías>(query, parameters);
            return categoria;
        }

        public async Task<bool> DeleteCategoriaAsync(int id)
        {
            string query = "DELETE FROM Categorías WHERE CategoriaID = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            return await databaseRepository.DeleteAsync(query, parameters);
        }
    }
}
