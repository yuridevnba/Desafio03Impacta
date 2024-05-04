using System.ComponentModel.DataAnnotations;

namespace ControleVendas.Models
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }

        [Required(ErrorMessage = "O nome é requerido!")]
        [MinLength(3)]
        public string? Nome { get; set; }

        [MinLength(11)]
        [MaxLength(11)]
        public string? CPF { get; set; }

        [Range(18, 70)]
        public int Idade { get; set; }

        public string? Sexo { get; set; }

        public string? Endereço {  get; set; }

        public string? Estado{ get; set; }

        public string? Municipio { get; set; }

        public string? Numero { get; set; }

        public string? Complemento { get; set; }

        public string? Escolaridade { get; set; }

        public string? Telefone { get; set; }


        public string? Email { get; set; }
        public decimal TotalVendas { get; set; }




    }
}
