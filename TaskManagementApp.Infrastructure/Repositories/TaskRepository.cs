using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoService.Models.Models;
using VideoService.Services.Interfaces;

namespace TaskManagementApp.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IConfiguration _configuration;
        public TaskRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> Add(VideoModel entity)
        {
            var sql = "INSERT INTO Video (Name, Path, CategoryId, Status, IsCorrect) Values (@Name, @Path, @CategoryId, @Status, @IsCorrect);";

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
            var sql = "DELETE FROM Video WHERE Id = @Id;";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                // Open the connection
                connection.Open();

                var affectedRow = await connection.ExecuteAsync(sql, new { Id = id });

                return affectedRow;
            }
        }

        public async Task<VideoModel> Get(int id)
        {
            var sql = "SELECT * FROM Video WHERE Id = @Id;";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                // Open the connection
                connection.Open();

                var result = await connection.QueryAsync<VideoModel>(sql, new { Id = id });

                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<VideoModel>> GetAll()
        {
            var sql = "SELECT * FROM Video;";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                // Open the connection
                connection.Open();

                var result = await connection.QueryAsync<VideoModel>(sql);

                return result;
            }
        }

        public async Task<int> Update(VideoModel entity)
        {
            var sql = "UPDATE Video SET Name = @Name, Path = @Path, CategoryId = @CategoryId, Status = @Status, IsCorrect = @IsCorrect WHERE Id = @Id;";

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
