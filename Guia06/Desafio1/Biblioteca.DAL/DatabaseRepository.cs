using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Common;
using Biblioteca.DAL.Interfaces;
using Dapper;
using Microsoft.Extensions.Options;


namespace Biblioteca.DAL
{
    public class DatabaseRepository : IDatabaseRepository
    {
        private readonly string connectionString;

        public DatabaseRepository(IOptions<AppSettings> appSettings)
        {
            connectionString = appSettings.Value.ConnectionString;
        }

        public async Task<List<T>> GetDataByQueryAsync<T>(string query, DynamicParameters? parameters = null)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<T>(query, parameters);
                    connection.Close();
                    return result.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("erro en GetDataByQueryAsync : " + e.Message);
            }
        }

        public async Task<int> InsertAsync(string query, DynamicParameters? parameters = null)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var result = await connection.QuerySingleOrDefaultAsync<int>(query, parameters);
                    connection.Close();
                    return result;
                }
            }
            catch (Exception e)
            {
                throw new Exception("erro en InsertAsync : " + e.Message);
            }
        }

        public async Task<T?> UpdateAsync<T>(string query, DynamicParameters? parameters = null)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<T>(query, parameters);
                    connection.Close();
                    if (result != null && result.Any())
                    {
                        return result.FirstOrDefault();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("erro en UpdateAsync : " + e.Message);
            }
            return default;
        }

        public async Task<bool> DeleteAsync(string query, DynamicParameters? parameters = null)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var result = await connection.QuerySingleOrDefaultAsync<bool>(query, parameters);
                    connection.Close();
                    return result;
                }
            }
            catch (Exception e)
            {
                throw new Exception("erro en DeleteAsync : " + e.Message);
            }
        }

    }
}
