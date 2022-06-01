namespace MGM.MVP.StorageTable.Entities
{
    public class Pedido : Entity
    {
        public int GrupoId { get; set; }
        
        public int RegraId { get; set; }
        
        public string User { get; set; }

        public long Id { get; set; }

        public string Dados { get; set; }
    }
}
