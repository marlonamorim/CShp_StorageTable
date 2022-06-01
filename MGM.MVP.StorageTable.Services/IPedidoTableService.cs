using MGM.MVP.StorageTable.Entities;

namespace MGM.MVP.StorageTable.Services
{
    public interface IPedidoTableService : ITableService<Pedido>
    {
        void InsertPedido(Pedido pedido);

        void UpdatePedido(Pedido pedido);
    }
}
