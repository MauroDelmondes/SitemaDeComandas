using System.ComponentModel.DataAnnotations;

namespace SitemaDeComandas.Models
{
    public class SituacaoComanda
    {
        [Key]
        public required int SituacaoComandaId { get; set; }
        [Required]
        public required string Descricao { get; set; }
        [Required]
        public required bool Ativo { get; set; }
        [Required]
        public required DateTime DataHoraCriacao { get; set; }
        public DateTime? DataHoraAlteracao { get; set; }

        public ICollection<Comanda>? Comandas { get; set; }
    }
}
