﻿using App.Seguro.Infra.Repository;
using App.Seguro.Models;
using App.Seguro.Models.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;


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
        private readonly ICalculoSeguroVeiculoRepository _repo;

        public SeguroVeiculoService(ICalculoSeguroVeiculoRepository repo)
        {
            _repo = repo;
        }

        static double MARGEM_SEGURA = 0.03;
        static double LUCRO = 0.05;

        public double CalcularSeguro(CalculoSeguroVeiculoInput input)
        {

            double taxaRisco = ((input.ValorVeiculo * 5) / (input.ValorVeiculo * 2) / 100);
            double premioRisco = taxaRisco * input.ValorVeiculo;
            double premioPuro = premioRisco * (1 + MARGEM_SEGURA);
            double premioComercial = (LUCRO * premioPuro) + premioPuro;

            if (premioComercial < 0)
                premioComercial = 0;

            CalculoSeguroVeiculo model = new CalculoSeguroVeiculo { CPF = input.CPF, Idade = input.Idade, Marca = input.Marca,Modelo = input.Modelo, Veiculo = input.Veiculo, Nome = input.Nome, ValorVeiculo = input.ValorVeiculo, DataCalculo = DateTime.Now, IdCalculo = Guid.NewGuid(), Lucro = LUCRO, Margem = MARGEM_SEGURA, PremioComercial = premioComercial, PremioPuro = premioPuro, TaxaRisco = taxaRisco };

            _repo.CriarCalculoSeguro(model);

            return premioComercial;

        }


        public List<CalculoSeguroVeiculo> Relatorio()
        {
            return _repo.BuscarTodosRegistros();
        }

        public CalculoSeguroVeiculo BuscarSeguro(string cpf)
        {
            var seguros = _repo.BuscarPorCPF(cpf).OrderByDescending(x => x.DataCalculo).ToList();

            return seguros.FirstOrDefault();

        }

        public List<CalculoSeguroVeiculo> BuscarSeguros(string cpf)
        {
            return _repo.BuscarPorCPF(cpf);
        }
    }
}
