using Estacionamento.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Estacionamento.Models
{
    public class TabelaPrecoModel
    {
        [Key]
        public int Id { get; set; }

        public decimal PrecoPorHora { get; set; }
        public decimal ValorHoraAdicional { get; set; }
        public int MinutoTolerancia { get; set; }
        public DateTime InicioVigencia { get; set; }
        public DateTime FinalVigencia { get; set; }

    }
}
