using Azure;
using Azure.Data.Tables;
using StarkAPI.Models;

namespace StarkAPI.Data
{
    public class TableStorageService
    {
        private readonly TableClient _tableClient;

        public TableStorageService(string storageConnectionString, string tableName)
        {
            _tableClient = new TableClient(storageConnectionString, tableName);
        }

        public async Task<List<TableEntity>> GetAllEntitiesAsync()
        {
            var entities = new List<TableEntity>();
            await foreach (var entity in _tableClient.QueryAsync<TableEntity>())
            {
                entities.Add(entity);
            }
            return entities;
        }
        
    }
}
