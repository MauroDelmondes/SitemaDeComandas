using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SitemaDeComandas.Models
{
    public class Cozinha
    {
        [Key]
        public required int CozinhaId { get; set; }
        [Required]
        public required string Descricao { get; set; }
        [Required]
        public required bool Ativo { get; set; }
        [Required]
        public required DateTime DataHoraCriacao { get; set; }
        public DateTime? DataHoraAlteracao { get; set; }
        
        public ICollection<Produto>? Produtos { get; set; }
        public ICollection<Comanda>? Comandas { get; set; }
    }
}
