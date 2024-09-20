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
    public class LibroRepository : ILibroRepository
    {
        private readonly IDatabaseRepository databaseRepository;

        public LibroRepository(IDatabaseRepository databaseRepository)
        {
            this.databaseRepository = databaseRepository;
        }

        public async Task<List<Libro>> GetLibrosAsync()
        {
            string query = "SELECT LibroID AS id, Titulo, FechaPublicacion, AutorID, CategoriaID FROM Libros";
            return (await databaseRepository.GetDataByQueryAsync<Libro>(query)).ToList();
        }

        public async Task<Libro> GetLibroByIdAsync(int id)
        {
            string query = "SELECT LibroID AS id, Titulo, FechaPublicacion, AutorID, CategoriaID FROM Libros WHERE LibroID = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            return (await databaseRepository.GetDataByQueryAsync<Libro>(query, parameters)).FirstOrDefault();
        }

        public async Task<int> InsertLibroAsync(Libro libro)
        {
            string query = @"INSERT INTO Libros (Titulo, FechaPublicacion, AutorID, CategoriaID) 
                         VALUES (@Titulo, @FechaPublicacion, @AutorID, @CategoriaID);
                         SELECT SCOPE_IDENTITY();";
            var parameters = new DynamicParameters();
            parameters.Add("@Titulo", libro.Titulo);
            parameters.Add("@FechaPublicacion", libro.FechaPublicacion);
            parameters.Add("@AutorID", libro.AutorID);
            parameters.Add("@CategoriaID", libro.CategoriaID);
            return await databaseRepository.InsertAsync(query, parameters);
        }

        public async Task<Libro> UpdateLibroAsync(Libro libro)
        {
            string query = @"UPDATE Libros 
                            SET Titulo = @Titulo, FechaPublicacion = @FechaPublicacion, 
                            AutorID = @AutorID, CategoriaID = @CategoriaID
                            WHERE LibroID = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", libro.id);
            parameters.Add("@Titulo", libro.Titulo);
            parameters.Add("@FechaPublicacion", libro.FechaPublicacion);
            parameters.Add("@AutorID", libro.AutorID);
            parameters.Add("@CategoriaID", libro.CategoriaID);
            await databaseRepository.UpdateAsync<Libro>(query, parameters);
            return libro;
        }

        public async Task<bool> DeleteLibroAsync(int id)
        {
            string query = @"DELETE FROM Libros WHERE LibroID = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            return await databaseRepository.DeleteAsync(query, parameters);
        }
    }
}
