using System.ComponentModel.DataAnnotations;

namespace SitemaDeComandas.Models
{
    public class FormaPagamento
    {
        [Key]
        public required int FormaPagamentoId { get; set; }
        [Required]
        public required string Descricao { get; set; }
        [Required]
        public required bool Ativo { get; set; }
        [Required]
        public required DateTime DataHoraCriacao { get; set; }
        public DateTime? DataHoraAlteracao { get; set; }

        public ICollection<Venda>? Vendas { get; set; }
    }
}
