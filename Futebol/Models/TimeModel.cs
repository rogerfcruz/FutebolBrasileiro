using System;
using System.ComponentModel.DataAnnotations;

namespace Futebol.Models
{
    public class TimeModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} tamanho deve ser entre {2} e {1}.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "{0} tamanho deve ser entre {2} e {1}.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} tamanho deve ser entre {2} e {1}.")]
        public string Cidade { get; set;}

        [Display(Name = "Data Fundação")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "{0} obrigatório")]
        public DateTime DataFundacao { get; set; }

        [Display(Name = "Nome do Estádio")]
        [Required(ErrorMessage = "{0} obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} tamanho deve ser entre {2} e {1}.")]
        public String NomeEstadio { get; set; }

        public TimeModel()
        {
        }
        public TimeModel(int id, string nome, string estado, string cidade, DateTime dataFundacao, string nomeEstadio)
        {
            Id = id;
            Nome = nome;
            Estado = estado;
            Cidade = cidade;
            DataFundacao = dataFundacao;
            NomeEstadio = nomeEstadio;
        }
    }
}
