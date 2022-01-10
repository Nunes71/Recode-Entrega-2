using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Models
{
    public class VendaDeArtesanatos
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NomeDoProduto { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [Required]
        public int QuantidadeProduzida { get; set; }
    }
}
