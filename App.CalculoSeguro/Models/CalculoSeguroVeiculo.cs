using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Seguro.Models
{
    public class CalculoSeguroVeiculo
    {
        public Guid IdCalculo { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public int Idade { get; set; }
        public string Marca_Modelo { get; set; }
        public double ValorVeiculo { get; set; }
        public double Margem { get; set; }
        public double Lucro { get; set; }
        public double TaxaRisco { get; set; }
        public double PremioPuro { get; set; }
        public double PremioComercial { get; set; }
        public DateTime DataCalculo { get; set; }
    }
}
