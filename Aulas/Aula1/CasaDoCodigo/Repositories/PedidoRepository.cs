﻿using CasaDoCodigo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CasaDoCodigo.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        private readonly IHttpContextAccessor contextAccessor;
        public PedidoRepository(ApplicationContext contexto, IHttpContextAccessor contextAccessor) : base(contexto)
        {
            this.contextAccessor = contextAccessor;
        }

        public void AddItem(string codigoProduto)
        {
            var produto = contexto.Set<Produto>()
                .Where(p => p.Codigo == codigoProduto).SingleOrDefault();

            if (produto == null)
            {
                throw new ArgumentException("Produto não encontrado");

            }

            var pedido = GetPedido();

            var itemPedido = contexto.Set<ItemPedido>()
                .Where(i => i.Produto.Codigo == codigoProduto 
                && i.Pedido.Id == pedido.Id).SingleOrDefault();   

            if (itemPedido == null)
            {
                itemPedido = new ItemPedido(pedido, produto, 1, produto.Preco);
                contexto.Set<ItemPedido>().Add(itemPedido);
                contexto.SaveChanges();
            }


        }

        public Pedido GetPedido()
        {
            var pedidoId = GetPedidoId();
            var pedido = dbSet
                .Include(i => i.Itens)
                .ThenInclude(p => p.Produto)
                .Where(p => p.Id == pedidoId).SingleOrDefault();
            if (pedido == null)
            {
                pedido = new Pedido();
                dbSet.Add(pedido);
                contexto.SaveChanges();
                SetPedidoId(pedido.Id);
            }
            
            return pedido;
        }

        private int? GetPedidoId()
        {
            return contextAccessor.HttpContext.Session.GetInt32("pedidoId");
        }

        private void SetPedidoId(int pedidoId)
        {
            contextAccessor.HttpContext.Session.SetInt32("pedidoId", pedidoId);
        }
    }
}
