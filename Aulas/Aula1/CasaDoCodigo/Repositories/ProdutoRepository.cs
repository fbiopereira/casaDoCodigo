using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CasaDoCodigo.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public IList<Produto> GetProdutos()
        {
            return dbSet.ToList<Produto>();
        }

        public void SaveProdutos(List<Produto> produtos)
        {

            foreach (var produto in produtos)
            {
                
                if (!dbSet.Where(p => p.Codigo == produto.Codigo).Any())
                {
                    dbSet.Add(produto);
                }
                
            }
            contexto.SaveChanges();
        }
    }
}
