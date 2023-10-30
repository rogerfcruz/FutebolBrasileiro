using System;
using System.ComponentModel.DataAnnotations;

namespace Futebol.Models
{
    public class CampeonatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} tamanho deve ser entre {2} e {1}.")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Data Início")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Data Fim")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "{0} obrigatório")]
        public DateTime DataFim { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} tamanho deve ser entre {2} e {1}.")]
        public string Tipo { get; set; }

        [Display(Name = "Valor (PTS)")]
        [Required(ErrorMessage = "{0} obrigatório")]
        public int Valor { get; set; }

        public CampeonatoModel()
        {
        }
        public CampeonatoModel(int id, string nome, DateTime dataInicio, DateTime dataFim, string tipo, int valor)
        {
            Id = id;
            Nome = nome;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Tipo = tipo;
            Valor = valor;
        }
    }
}
