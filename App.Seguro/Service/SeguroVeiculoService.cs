using App.Seguro.Models.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teste.Models;
using teste.Shared;

namespace App.Seguro.Service
{

    public interface ISeguroVeiculoService
    {
        double CalcularSeguro(CalculoSeguroVeiculoInput input);
        List<CalculoSeguroVeiculo> Relatorio();
        CalculoSeguroVeiculo BuscarSeguro(string cpf);
        List<CalculoSeguroVeiculo> BuscarSeguros(string cpf);

    }

    public class SeguroVeiculoService : ISeguroVeiculoService
    {
        private readonly IContext _context;
        public SeguroVeiculoService(IContext context)
        {
            _context = context;
        }

        static double MARGEM_SEGURA = 0.03;
        static double LUCRO = 0.05;

        public double CalcularSeguro(CalculoSeguroVeiculoInput input)
        {

            double taxaRisco = ((input.ValorVeiculo * 5) / (input.ValorVeiculo * 2) / 100);
            double premioRisco = taxaRisco * input.ValorVeiculo;
            double premioPuro = premioRisco * (1 + MARGEM_SEGURA);
            double premioComercial = (LUCRO * premioPuro) + premioPuro;

            CalculoSeguroVeiculo model = new CalculoSeguroVeiculo { CPF= input.CPF, Idade = input.Idade, Marca_Modelo = input.Marca_Modelo, Nome = input.Nome, ValorVeiculo = input.ValorVeiculo, DataCalculo = DateTime.Now, IdCalculo = Guid.NewGuid(), Lucro = LUCRO, Margem = MARGEM_SEGURA, PremioComercial = premioComercial, PremioPuro = premioPuro, TaxaRisco = taxaRisco};

            _context.CalculoSeguroVeiculo.Add(model);
            _context.Commit();

            return premioComercial;


        }

        public List<CalculoSeguroVeiculo> Relatorio()
        {
            return _context.CalculoSeguroVeiculo.ToList();
        }

        public CalculoSeguroVeiculo BuscarSeguro(string cpf)
        {
            var seguros =  _context.CalculoSeguroVeiculo.Where(x => x.CPF == cpf).OrderByDescending(x=> x.DataCalculo).ToList();

            return seguros.FirstOrDefault();
          
        }

        public List<CalculoSeguroVeiculo> BuscarSeguros(string cpf)
        {
            return _context.CalculoSeguroVeiculo.Where(x => x.CPF == cpf).ToList();
        }
    }
}
