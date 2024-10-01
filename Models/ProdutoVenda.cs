using System.ComponentModel.DataAnnotations;

namespace SitemaDeComandas.Models
{
    public class ProdutoVenda
    {
        [Key]
        public int ProdutoVendaId { get; set; }
        public int VendaId { get; set; }
        public int ProdutoId { get; set; } //prato e etc.
        public int Quantidade { get; set; }
        public double PrecoUnitario { get; set; }
        public double PrecoTotal { get; set; }
    }
}
