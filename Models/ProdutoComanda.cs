﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SitemaDeComandas.Models
{
    public class ProdutoComanda
    {
        [Key]
        public required int PratoComandaId { get; set; }
        [Required]
        public required int ProdutoId { get; set; } //Prato
        [Required]
        public required int ComandaId { get; set; }

        [ForeignKey(nameof(ProdutoId))]
        public Produto? Produto { get; set; }
        [ForeignKey(nameof(ComandaId))]
        public Comanda? Comanda { get; set; }

    }
}
