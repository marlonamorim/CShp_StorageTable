using Azure.Data.Tables;
using MGM.MVP.StorageTable.Entities;
using System;

namespace MGM.MVP.StorageTable.Services
{
    public class PedidoTableService : TableService<Pedido>, IPedidoTableService
    {
        public PedidoTableService(TableClient tableClient) : base(tableClient)
        {
        }

        public void InsertPedido(Pedido pedido)
        {
            pedido.ObservationDate = DateTime.Now.Date.ToString("yyyy-MM-dd");
            pedido.ObservationTime = DateTime.Now.ToString("HH:mm:ss");

            TableEntity entity = new TableEntity
            {
                PartitionKey = pedido.StationName,
                RowKey = $"{pedido.Id}_{pedido.ObservationDate} {pedido.ObservationTime}"
            };

            entity["RegraId"] = pedido.RegraId;
            entity["GrupoId"] = pedido.GrupoId;
            entity["Id"] = pedido.Id;
            entity["User"] = pedido.User;
            entity["Dados"] = pedido.Dados;

            InsertTableEntity(entity);
        }

        public void UpdatePedido(Pedido pedido)
        {
            TableEntity entity = new TableEntity
            {
                PartitionKey = pedido.StationName,
                RowKey = $"{pedido.Id}_{pedido.ObservationDate} {pedido.ObservationTime}"
            };

            entity["RegraId"] = pedido.RegraId;
            entity["GrupoId"] = pedido.GrupoId;
            entity["Id"] = pedido.Id;
            entity["User"] = pedido.User;
            entity["Dados"] = pedido.Dados;

            UpsertTableEntity(entity);
        }
    }
}
