using System.ComponentModel.DataAnnotations;

namespace ControleVendas.Models
{
    public class Produto
    {
        public int ProdutoID { get; set; }


        
        [MinLength(3)]
        public string? Nome { get; set; }


        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Preco { get; set; }


        public int quantidade { get; set; }


        public DateTime HoraCriacao { get; set; }


        

    }
}
