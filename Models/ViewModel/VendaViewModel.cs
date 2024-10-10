namespace SitemaDeComandas.Models.ViewModel
{
    public class VendaViewModel 
    {
        public IList<Produto> Produtos { get; set; }
        public string NomeCliente { get; set; }
        public int FormaPagamentoId { get; set; }
        public int SituacaoVendaId { get; set; }
        public double PrecoTotal { get; set; }
    }
}
