using Azure;
using Azure.Data.Tables;
using StarkAPI.Models;
using Microsoft.Extensions.Configuration;

namespace StarkAPI.Data
{
    public class DataService
    {
        public string ConnectionStringName { get; set; } = "Default";
        private readonly IConfiguration _config;
        private readonly TableStorageService _tableStorageService;
        public DataService(IConfiguration config )
        {
            _config = config;

            string connectionString = _config.GetConnectionString(ConnectionStringName);
                  _tableStorageService = new TableStorageService(connectionString,"DadJokes");
        }

        public async Task<List<Joke>> GetJokes(string TableName)
        {
            var a = await _tableStorageService.GetAllEntitiesAsync();
            var entities = new List<Joke>();

            foreach (var entity in a)
            {
                var Userkey = entity.GetString("userkey");
                var keyValue = entity.GetString("gatoid");
                var joke = new Joke
                {
                    // Populate the Credi instance with data from the entity
                    PartitionKey = entity.PartitionKey,
                    RowKey = entity.RowKey,
                    Leadin = entity.GetString("leadin"),
                    Hit = entity.GetString("hit"),
                    Category = entity.GetString("category")
                    // Add other properties as needed
                };
                entities.Add(joke);
            }

            return entities;
        }
    }
}
