using System;
using System.Collections.Generic;

namespace MGM.MVP.StorageTable.WebApi.Filter
{
    public static class PedidoFilterExtension
    {
        public static IList<string> ApplyFilter(this FilterResultsInputModel inputModel)
        {
            List<string> filters = new List<string>();

            if (!String.IsNullOrEmpty(inputModel.PartitionKey))
                filters.Add($"PartitionKey eq '{inputModel.PartitionKey}'");
            if (!String.IsNullOrEmpty(inputModel.RowKeyDateStart) && !String.IsNullOrEmpty(inputModel.RowKeyTimeStart))
                filters.Add($"RowKey ge '{inputModel.RowKeyDateStart} {inputModel.RowKeyTimeStart}'");
            if (!String.IsNullOrEmpty(inputModel.RowKeyDateEnd) && !String.IsNullOrEmpty(inputModel.RowKeyTimeEnd))
                filters.Add($"RowKey le '{inputModel.RowKeyDateEnd} {inputModel.RowKeyTimeEnd}'");
            if (inputModel.RegraId.HasValue)
                filters.Add($"RegraId eq {inputModel.RegraId.Value}");
            if (inputModel.GrupoId.HasValue)
                filters.Add($"GrupoId eq {inputModel.GrupoId.Value}");
            if (inputModel.PedidoId.HasValue)
                filters.Add($"Pedido eq {inputModel.PedidoId.Value}");
            if (!String.IsNullOrEmpty(inputModel.User))
                filters.Add($"User eq '{inputModel.User}'");

            return filters;
        }
    }
}
