using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Seguro.Models.Inputs
{
    public class CalculoSeguroVeiculoInput
    {

        public string Nome { get; set; }
        public string CPF { get; set; }
        public int Idade { get; set; }
        public string Marca_Modelo { get; set; }
        public double ValorVeiculo { get; set; }
    }
}
