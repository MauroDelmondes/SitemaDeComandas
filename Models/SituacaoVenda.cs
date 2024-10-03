using System.ComponentModel.DataAnnotations;

namespace SitemaDeComandas.Models
{
    public class SituacaoVenda
    {
        [Key]
        public required int SituacaoVendaId { get; set; }
        [Required]
        public required string Descricao { get; set; }
        [Required]
        public required int Ativo { get; set; }
        [Required]
        public required DateTime DataHoraCriacao { get; set; }
        public DateTime? DataHoraAlteracao { get; set; }

        public ICollection<Venda>? Vendas { get; set; }
    }
}
