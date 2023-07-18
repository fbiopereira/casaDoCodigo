using CasaDoCodigo.Models;
using System.Linq;

namespace CasaDoCodigo.Repositories
{
    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public void UpdateQuantidade(ItemPedido itemPedido)
        {
            var itemPedidoDB = dbSet
                .Where(item => item.Id == itemPedido.Id).SingleOrDefault();

            if (itemPedidoDB != null) {

                itemPedidoDB.AtualizaQuantidade(itemPedido.Quantidade);
                contexto.SaveChanges();
            }

        }
    }
}
