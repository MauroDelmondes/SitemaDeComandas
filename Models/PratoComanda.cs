using System.ComponentModel.DataAnnotations;

namespace SitemaDeComandas.Models
{
    public class PratoComanda
    {
        [Key]
        public int PratoComandaId { get; set; }
        public int PratoId { get; set; }
        public int ComandaId { get; set; }
        public int SituacaoId { get; set; }
        public DateTime DataHoraCriacao { get; set; }
        public DateTime? DataHoraAlteracao { get; set; }
    }
}
