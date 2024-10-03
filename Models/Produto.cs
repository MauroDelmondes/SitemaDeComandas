using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SitemaDeComandas.Models
{
    public class Produto
    {
        [Key]
        public required int ProdutoId { get; set; }
        [Required]
        public required string Nome { get; set; }
        public string? Descricao { get; set; }
        public int? CozinhaId { get; set; }
        [Required]
        public required double Preco { get; set; }
        [Required]
        public required bool Ativo { get; set; } //bit
        [Required]
        public required DateTime DataHoraCriacao { get; set; }
        public DateTime? DataHoraAlteracao { get; set; }
        
        [ForeignKey(nameof(CozinhaId))]
        public Cozinha? Cozinha { get; set; }
        public ICollection<ProdutoVenda>? ProdutosVendas { get; set; }
        public ICollection<ProdutoComanda>? ProdutosComandas { get; set; }
    }
}
