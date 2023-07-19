using CasaDoCodigo.Models;
using System.Collections.Generic;

namespace CasaDoCodigo.Repositories
{
    public interface IPedidoRepository
    {
        void AddItem(string codigoProduto);
        Pedido GetPedido();
        UpdateQuantidadeResponse UpdateQuantidade(ItemPedido itemPedido);
    }
}