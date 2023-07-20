using System;
using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.Models
{

    public class Cadastro : ModeloBase
    {
        public Cadastro()
        {
        }

        public virtual Pedido Pedido { get; set; }

        [MinLength(5, ErrorMessage = "O NOME deve ter no mínimo 5 caracteres")]
        [MaxLength(50, ErrorMessage = "O NOME deve ter no máximo 50 caracteres")]
        [Required(ErrorMessage ="O NOME é obrigatório")]
        public string Nome { get; set; } = "";
        [EmailAddress(ErrorMessage = "Formato de E-MAIL inválido")]
        [Required(ErrorMessage = "O E-MAIL é obrigatório")]
        public string Email { get; set; } = "";
        [Required(ErrorMessage = "O TELEFONE é obrigatório")]
        public string Telefone { get; set; } = "";
        [Required(ErrorMessage = "O ENDEREÇO é obrigatório")]
        public string Endereco { get; set; } = "";
        [Required(ErrorMessage = "O COMPLEMENTO é obrigatório")]
        public string Complemento { get; set; } = "";
        [Required(ErrorMessage = "O BAIRRO é obrigatório")]
        public string Bairro { get; set; } = "";
        [Required(ErrorMessage = "O MUNICÍPIO é obrigatório")]
        public string Municipio { get; set; } = "";
        [Required(ErrorMessage = "A UF é obrigatória")]
        public string UF { get; set; } = "";
        [Required(ErrorMessage = "O CEP é obrigatório")]
        public string CEP { get; set; } = "";

        internal void Update(Cadastro novoCadastro)
        {
            this.Bairro = novoCadastro.Bairro;
            this.CEP = novoCadastro.CEP;
            this.Complemento = novoCadastro.Complemento;
            this.Email = novoCadastro.Email;
            this.Endereco = novoCadastro.Endereco;
            this.Municipio = novoCadastro.Municipio;
            this.Nome = novoCadastro.Nome;
            this.Telefone = novoCadastro.Telefone;
            this.UF = novoCadastro.UF;
        }
    }

}
