using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SitemaDeComandas.Models
{
    public class Comanda //CozinhaVenda
    {
        [Key]
        public required int ComandaId { get; set; }
        [Required]
        public required int VendaId { get; set; }
        [Required]
        public required int CozinhaId { get; set; }
        [Required]
        public required int SituacaoComandaId { get; set; }
        [Required]
        public required bool Viagem { get; set; }
        [Required]
        public required DateTime DataHoraCriacao { get; set; }
        public DateTime? DataHoraAlteracao { get; set; }

        [ForeignKey(nameof(VendaId))]
        public Venda? Venda { get; set; }
        [ForeignKey(nameof(CozinhaId))]
        public Cozinha? Cozinha { get; set; }
        [ForeignKey(nameof(SituacaoComandaId))]
        public SituacaoComanda? SituacaoComanda { get; set; }
        public ICollection<ProdutoComanda>? ProdutosComandas { get; set; }
    }
}
