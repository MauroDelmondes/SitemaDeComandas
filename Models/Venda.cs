using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SitemaDeComandas.Models
{
    public class Venda
    {
        [Key]
        public required int VendaId { get; set; }
        [Required]
        public required string NomeCliente { get; set; }
        [Required]
        public required int FormaPagamentoId { get; set; } //Pix, cartão de crédito, débito, dinheiro e etc.
        [Required]
        public required int SituacaoVendaId { get; set; } //Pago, cancelado, estornado e etc.
        [Required]
        public required double PrecoTotal { get; set; }
        [Required]
        public required DateTime DataHoraVenda { get; set; }
        public DateTime? DataHoraAlteracao { get; set; }
               
        [ForeignKey(nameof(FormaPagamentoId))]
        public FormaPagamento? FormaPagamento { get; set; }
        [ForeignKey(nameof(SituacaoVendaId))]
        public SituacaoVenda? SituacaoVenda { get; set; }
        public ICollection<ProdutoVenda>? ProdutosVendas { get; set; }
        public ICollection<Comanda>? Comandas { get; set; }
    }
}
