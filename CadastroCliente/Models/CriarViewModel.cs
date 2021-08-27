using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroCliente.Models
{
    [Table("DbClientes")]
    public class CriarViewModel
    {       
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo RG é obrigatório.")]
        public string RG { get; set; }
        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string NomeMae { get; set; }
        public string NomePai { get; set; }
        public string Email { get; set; }
       
    }
}
