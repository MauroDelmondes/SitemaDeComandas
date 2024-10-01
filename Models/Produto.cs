namespace SitemaDeComandas.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public int? CozinhaId { get; set; }
        public double Preco { get; set; }
        public int Ativo { get; set; }
        public DateTime DataHoraCriacao { get; set; }
        public DateTime? DataHoraAlteracao { get; set; }
    }
}
