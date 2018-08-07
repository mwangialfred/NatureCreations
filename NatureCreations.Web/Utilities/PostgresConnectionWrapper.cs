

using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Npgsql;

namespace NatureCreations.Web.Utilities
{
    public interface IPostgresConnectionWrapper
    {
        NpgsqlConnection Connect();
        Task<T> GetAsync<T>(NpgsqlConnection connection, object accountIdentifier) where T : class;
        Task InsertAsync<T>(NpgsqlConnection connection, T entity) where T : class;
        Task UpdateAsync<T>(NpgsqlConnection connection, T entity) where T : class;
    }
    public class PostgresConnectionWrapper : IPostgresConnectionWrapper
    {
        private readonly string _connectionString;

        public PostgresConnectionWrapper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public NpgsqlConnection Connect()
        {
            return new NpgsqlConnection(_connectionString);
        }

        public async Task<T> GetAsync<T>(NpgsqlConnection connection, object id) where T : class
        {
            return await connection.GetAsync<T>(id);
        }

        public async Task InsertAsync<T>(NpgsqlConnection connection, T entity) where T : class
        {
            await connection.InsertAsync(entity);
        }

        public async Task UpdateAsync<T>(NpgsqlConnection connection, T entity) where T : class
        {
            await connection.UpdateAsync(entity);
        }
    }
}
