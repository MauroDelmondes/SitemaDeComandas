using System.ComponentModel.DataAnnotations;

namespace SitemaDeComandas.Models
{
    public class Comanda //CozinhaVenda
    {
        [Key]
        public int ComandaId { get; set; }
        public int VendaId { get; set; }
        public int CozinhaId { get; set; }
        public int SituacaoId { get; set; }
        public bool Viagem { get; set; }
        public bool FilaVIP { get; set; }
        public DateTime DataHoraCriacao { get; set; }
        public DateTime? DataHoraAlteracao { get; set; }
        //Adicionar a posicao da comanda na fila? Ou criar uma tabela para gerenciar esta fila?
        //cancelar/editar prato na comanda
    }
}
