using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SitemaDeComandas.Models
{
    public class ProdutoVenda
    {
        [Key]
        public required int ProdutoVendaId { get; set; }
        [Required]
        public required int VendaId { get; set; }
        [Required]
        public required int ProdutoId { get; set; } //prato e etc.
        [Required]
        public required int Quantidade { get; set; }
        [Required]
        public required double PrecoUnitario { get; set; }
        [Required]
        public required double PrecoTotal { get; set; }

        [ForeignKey(nameof(VendaId))]
        public required Venda Venda { get; set; }
        [ForeignKey(nameof(ProdutoId))]
        public required Produto Produto { get; set; }
    }
}
