using System.ComponentModel.DataAnnotations;

namespace ControleVendas.Models
{
    public class Adm
    {

        public int AdmId { get; set; }

        [Required(ErrorMessage = "O Email é requerido!")]
        [MinLength(9)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A senha é requerido!")]
        [MinLength(10)]
        public string? Senha { get; set; }
    }
}
