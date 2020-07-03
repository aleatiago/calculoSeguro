using App.Seguro.Models;
using App.Seguro.Shared;
using System.Collections.Generic;
using System.Linq;



namespace App.Seguro.Infra.Repository
{



    public interface ICalculoSeguroVeiculoRepository
    {
        bool CriarCalculoSeguro(CalculoSeguroVeiculo inputs);
        List<CalculoSeguroVeiculo> BuscarTodosRegistros();
        List<CalculoSeguroVeiculo> BuscarPorCPF(string CPF);

    }

    public class CalculoSeguroVeiculoRepository : ICalculoSeguroVeiculoRepository
    {
        private readonly IContext _context;

        public CalculoSeguroVeiculoRepository(IContext context)
        {
            _context = context;
        }

        public List<CalculoSeguroVeiculo> BuscarPorCPF(string cpf)
        {
            return _context.CalculoSeguroVeiculo.Where(x => x.CPF == cpf).ToList();
        }

        public List<CalculoSeguroVeiculo> BuscarTodosRegistros()
        {
            return _context.CalculoSeguroVeiculo.ToList();
        }

        public bool CriarCalculoSeguro(CalculoSeguroVeiculo model)
        {
            try
            {
                _context.CalculoSeguroVeiculo.Add(model);
                _context.Commit();
            }
            catch
            {
                return false;
            }
            return true;
        }

    }
}
