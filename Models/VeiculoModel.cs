using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estacionamento.Models
{
    public class VeiculoModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Placa é obrigatório.")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "A placa deve ter 7 caracteres.")]
        public required string Placa { get; set; }

        [Required]
        public DateTime HorarioChegada { get; set; }

        public DateTime? HorarioSaida { get; set; }

        public TimeSpan? Duracao { get; set; }

        public int? TempoCobrado { get; set; }

        public string? Proprietario { get; set; }

        public decimal? Preco { get; set; }

        public decimal? ValorAPagar { get; set; }

        public bool? Estacionado { get; set;  }
    }
}