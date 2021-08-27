using System.ComponentModel.DataAnnotations;

namespace CadastroCliente.Models
{
    public class Cliente
    {
        public int ClienteId { get; internal set; }
        public string Nome { get; internal set; }
        public string RG { get; internal set; }
        public string CPF { get; internal set; }
        public string Telefone { get; internal set; }
        public string NomeMae { get; internal set; }
        public string NomePai { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}