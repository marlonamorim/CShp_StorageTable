namespace MGM.MVP.StorageTable.WebApi.Filter
{
    public class FilterResultsInputModel
    {
        public string PartitionKey { get; set; }
        public string RowKeyDateStart { get; set; }
        public string RowKeyTimeStart { get; set; }
        public string RowKeyDateEnd { get; set; }
        public string RowKeyTimeEnd { get; set; }
        public int? RegraId { get; set; }
        public int? GrupoId { get; set; }
        public long? PedidoId { get; set; }
        public string User { get; set; }
    }
}
