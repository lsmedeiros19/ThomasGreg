using System.ComponentModel.DataAnnotations;

namespace WebCliente.Models
{
    public class Logradouro
    {
        public int LogradouroId { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório")]
        [StringLength(200, ErrorMessage = "O endereço deve ter no máximo 200 caracteres")]
        public string Endereco { get; set; }

        public int ClienteId { get; set; }
    }
}
