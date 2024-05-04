using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleVendas.Models
{
    public class Vendas
    {
        public int VendasID { get; set; }

        public int FuncionarioId { get; set; }


        //public Funcionario Funcionario { get; set; }


        //// Definindo DefaultValueSql para GETDATE()
        //[Column(TypeName = "datetime2")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //public DateTime HoraVenda { get; set; }

        public string? produtos { get; set; }


        public int quantidade { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal? Preco { get; set; }

    }
}
