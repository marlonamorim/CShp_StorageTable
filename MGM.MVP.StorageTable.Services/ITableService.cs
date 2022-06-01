using Azure.Data.Tables;
using System.Collections.Generic;

namespace MGM.MVP.StorageTable.Services
{
    public interface ITableService<T> where T : class, new()
    {
        IEnumerable<T> GetAllRows(IList<string> filters);

        void InsertTableEntity(TableEntity entity);

        void UpsertTableEntity(TableEntity entity);

        void DeleteTableEntity(string partitionKey, string rowKey);
    }
}
