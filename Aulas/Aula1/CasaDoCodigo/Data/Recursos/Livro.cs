using CasaDoCodigo.Models;
using Newtonsoft.Json;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;
using System.Collections.Generic;
using System.IO;

namespace CasaDoCodigo.Data.Recursos
{
    public class Livro
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public static List<Produto> CarregarDados()
        {
            var json = File.ReadAllText("Data/Recursos/livros.json");
            var livros = JsonConvert.DeserializeObject<List<Livro>>(json);
            List<Produto> produtos = new List<Produto>();
            foreach (var livro in livros)
            {
                produtos.Add(new Produto(livro.Codigo, livro.Nome, livro.Preco));
            }

            return produtos;
        }
    }

   
}
