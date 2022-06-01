using Azure;
using Azure.Data.Tables;
using MGM.MVP.StorageTable.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MGM.MVP.StorageTable.Services
{
    public class TableService<T> 
        : ITableService<T>
        where T : Entity, new()
    {
        private readonly string[] EXCLUDE_TABLE_ENTITY_KEYS = { "PartitionKey", "RowKey", "Timestamp", "ETag" };

        private readonly TableClient _tableClient;
        public TableService(TableClient tableClient)
            => _tableClient = tableClient;

        public IEnumerable<T> GetAllRows(IList<string> filters)
        {
            string filter = filters?.Any() != true 
                ? "" 
                : string.Join(" and ", filters);

            Pageable<TableEntity> entities = _tableClient.Query<TableEntity>(filter);

            return entities.Select(e => MapTableEntityToDataModel(e));
        }

        public void InsertTableEntity(TableEntity entity)
            => _tableClient.AddEntity(entity);

        public void UpsertTableEntity(TableEntity entity)
            => _tableClient.UpsertEntity(entity);

        public void DeleteTableEntity(string partitionKey, string rowKey)
            => _tableClient.DeleteEntity(partitionKey, rowKey);

        public T MapTableEntityToDataModel(TableEntity entity)
        {
            var observation = new Entity();
            var measurements = entity.Keys.Where(key => !EXCLUDE_TABLE_ENTITY_KEYS.Contains(key));
            foreach (var key in measurements)
            {
                observation[key] = entity[key];
            }

            var json = JsonConvert.SerializeObject(observation.KeyValuePairs);

            var payload = JsonConvert.DeserializeObject<T>(json);
            payload.StationName = entity.PartitionKey;
            payload.ObservationDate = entity.RowKey;
            payload.Timestamp = entity.Timestamp;
            payload.Etag = entity.ETag.ToString();

            return payload;
        }
    }
}
