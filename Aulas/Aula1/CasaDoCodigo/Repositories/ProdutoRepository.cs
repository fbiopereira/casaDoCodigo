using CasaDoCodigo.Models;
using System.Collections.Generic;
using System.Linq;

namespace CasaDoCodigo.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationContext contexto;

        public ProdutoRepository(ApplicationContext contexto)
        {
            this.contexto = contexto;
        }

        public IList<Produto> GetProdutos()
        {
            return contexto.Set<Produto>().ToList<Produto>();
        }

        public void SaveProdutos(List<Produto> produtos)
        {
            foreach (var produto in produtos)
            {
                contexto.Set<Produto>().Add(produto);
            }
            contexto.SaveChanges();
        }
    }
}
