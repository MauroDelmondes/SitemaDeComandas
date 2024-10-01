using System.ComponentModel.DataAnnotations;

namespace SitemaDeComandas.Models
{
    public class Cozinha
    {
        [Key]
        public int CozinhaId { get; set; }
        public string? Descricao { get; set; }
        public int Ativo { get; set; }
        public DateTime DataHoraCriacao { get; set; }
        public DateTime? DataHoraAlteracao { get; set; }
    }
}
