using System;

namespace Futebol.Models
{
    public class CampeonatoModel
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Tipo { get; set; }
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
