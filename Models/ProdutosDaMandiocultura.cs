using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Models
{
    public class ProdutosDaMandiocultura
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NomeDoProduto { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [Required]
        public int QuantidadeProduzida { get; set; }

        [Required]
        public string DataDeFabricacao { get; set; }

        [Required]
        public string DataDeValidade { get; set; }



    }
}
