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
    public class AutorRepository: IAutorRepository
    {
        private readonly IDatabaseRepository databaseRepository;

        public AutorRepository(IDatabaseRepository databaseRepository)
        {
            this.databaseRepository = databaseRepository;
        }

        public async Task<List<Autor>> GetAutoresAsync()
        {
            string query = "SELECT AutorID AS id, nombre, apellido FROM Autores";
            return await databaseRepository.GetDataByQueryAsync<Autor>(query);
        }

        public async Task<Autor> GetAutorByIdAsync(int id)
        {
            string query = "SELECT AutorID AS id, nombre, apellido FROM Autores WHERE AutorID = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            return (await databaseRepository.GetDataByQueryAsync<Autor>(query, parameters)).FirstOrDefault();
        }

        public async Task<int> InsertAutorAsync(Autor autor)
        {
            string query = "INSERT INTO Autores (nombre, apellido) VALUES (@nombre, @apellido); SELECT SCOPE_IDENTITY()";
            var parameters = new DynamicParameters();
            parameters.Add("@nombre", autor.nombre);
            parameters.Add("@apellido", autor.apellido);
            return await databaseRepository.InsertAsync(query, parameters);
        }

        public async Task<Autor> UpdateAutorAsync(Autor autor)
        {
            string query = "UPDATE Autores SET nombre = @nombre, apellido = @apellido WHERE AutorID = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", autor.id);
            parameters.Add("@nombre", autor.nombre);
            parameters.Add("@apellido", autor.apellido);
            await databaseRepository.UpdateAsync<Autor>(query, parameters);
            return autor;
        }

        public async Task<bool> DeleteAutorAsync(int id)
        {
            string query = "DELETE FROM Autores WHERE AutorID = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            return await databaseRepository.DeleteAsync(query, parameters);
        }

    }
}
