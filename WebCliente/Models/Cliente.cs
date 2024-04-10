using System.ComponentModel.DataAnnotations;

namespace WebCliente.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        public string Logotipo { get; set; }

        //public virtual IList<Logradouro> Logradouros { get; set; }
        public virtual ICollection<Logradouro> Logradouros { get; set; }
    }
}
