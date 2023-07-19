using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;
using CasaDoCodigo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.Controllers
{
    public class PedidoController : Controller
    {

        private readonly IProdutoRepository produtoRepository;
        private readonly IPedidoRepository pedidoRepository;
        private readonly IItemPedidoRepository itemPedidoRepository;

        public PedidoController(IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository, IItemPedidoRepository itemPedidoRepository)
        {
            this.produtoRepository = produtoRepository;
            this.pedidoRepository = pedidoRepository;
            this.itemPedidoRepository = itemPedidoRepository;
        }

        public IActionResult Carrossel()
        {
            return View(produtoRepository.GetProdutos());
        }

        public IActionResult Carrinho(string codigoProduto)
        {
            if (!string.IsNullOrWhiteSpace(codigoProduto)) 
            {
                pedidoRepository.AddItem(codigoProduto);
            
            }
            Pedido pedido = pedidoRepository.GetPedido();
            CarrinhoViewModel carrinhoViewModel = new CarrinhoViewModel(pedido.Itens);
            return View(carrinhoViewModel);
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult Resumo()
        {
            Pedido pedido = pedidoRepository.GetPedido();
            return View(pedido);
        }

        [HttpPost]
        public UpdateQuantidadeResponse UpdateQuantidade([FromBody]ItemPedido itemPedido)
        {
            return pedidoRepository.UpdateQuantidade(itemPedido);
        }
    }
}
