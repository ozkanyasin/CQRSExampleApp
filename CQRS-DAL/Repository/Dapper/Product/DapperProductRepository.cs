using CQRS_DAL.Entities;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_DAL.Repository.Dapper
{
    public class DapperProductRepository : IDapperProductRepository
    {
        private readonly string _connectionString = "server=localhost;database=cqrsdb;user=root;port=3306;password=toortoor";
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            IEnumerable<Product> result = new List<Product>();
            var query = "SELECT * FROM Products";
            using (var connection = new MySqlConnection(_connectionString))
            {
                result = await connection.QueryAsync<Product>(query);
            }
            return result;
        }

        public async ValueTask<Product> GetByIdAsync(Guid id)
        {   
            var result = new Product();
            var query = $"SELECT * FROM Products WHERE Id LIKE '%{id}%'";
            using (var connection = new MySqlConnection(_connectionString))
            {
                var coming = await connection.QueryFirstOrDefaultAsync(query);
                result.Quantity = coming.Quantity;
                result.Price = coming.Price;
                result.Id = id;
                result.Name = coming.Name;
                result.CreateTime = coming.CreateTime;
            }
            return result;
        }
    }
}
