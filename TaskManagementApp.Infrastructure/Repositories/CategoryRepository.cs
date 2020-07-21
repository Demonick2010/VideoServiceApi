using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VideoService.Models.Models;
using VideoService.Services.Interfaces;

namespace TaskManagementApp.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IConfiguration _configuration;

        public CategoryRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> Add(Category entity)
        {
            var sql = "INSERT INTO Category (Name) Values (@Name);";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                // Open the connection
                connection.Open();

                var affectedRow = await connection.ExecuteAsync(sql, entity);

                return affectedRow;
            }
        }

        public async Task<int> Delete(int id)
        {
            var sql = "DELETE FROM Category WHERE Id = @Id;";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                // Open the connection
                connection.Open();

                var affectedRow = await connection.ExecuteAsync(sql, new { Id = id });

                return affectedRow;
            }
        }

        public async Task<Category> Get(int id)
        {
            var sql = "SELECT * FROM Category WHERE Id = @Id;";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                // Open the connection
                connection.Open();

                var result = await connection.QueryAsync<Category>(sql, new { Id = id });

                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var sql = "SELECT * FROM Category;";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                // Open the connection
                connection.Open();

                var result = await connection.QueryAsync<Category>(sql);

                return result;
            }
        }

        public async Task<int> Update(Category entity)
        {
            var sql = "UPDATE Category SET Name = @Name WHERE Id = @Id;";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                // Open the connection
                connection.Open();

                var affectedRow = await connection.ExecuteAsync(sql, entity);

                return affectedRow;
            }
        }
    }
}
