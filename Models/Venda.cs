using System.ComponentModel.DataAnnotations;

namespace SitemaDeComandas.Models
{
    public class Venda
    {
        [Key]
        public int VendaId { get; set; }
        public string? NomeCliente { get; set; }
        //public int PratoId { get; set; } //No futuro expandir para os demais produtos (bingo e etc.)
        public int FormaPagamentoId { get; set; } //Pix, cartão de crédito, débito, dinheiro e etc.
        //public int QuantidadePratos { get; set; } //No futuro expandir para os demais produtos (bingo e etc.)
        public double PrecoTotal { get; set; }
        public bool Pago { get; set; }
        public bool Cancelado { get; set; } //retirar no futuro?
        public DateTime DataHoraVenda { get; set; }
        public DateTime? DataHoraAlteracao { get; set; }
        //public DateTime? DataHoraEnviadoCozinha { get; set; }
    }
}
