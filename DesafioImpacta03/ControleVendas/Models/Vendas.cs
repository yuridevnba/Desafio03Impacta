using System.ComponentModel.DataAnnotations;

namespace ControleVendas.Models
{
    public class Vendas
    {
        public int VendasID { get; set; }

        //public Funcionario? funcionario { get; set; }

        public DateTime HoraVenda { get; set; }

        //public ICollection<Produto>? produtos { get; set; }


        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal? Preco { get; set; }

    }
}
