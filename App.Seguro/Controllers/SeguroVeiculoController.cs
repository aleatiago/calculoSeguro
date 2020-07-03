using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Seguro.Models.Inputs;
using App.Seguro.Service;
using Microsoft.AspNetCore.Mvc;
using teste.Models;

namespace teste.Controllers
{
    [Route("api/v1/seguro-veiculo")]
    [ApiController]
    public class SeguroVeiculoController : ControllerBase
    {
        private readonly ISeguroVeiculoService _serv;

        public SeguroVeiculoController(ISeguroVeiculoService serv)
        {
            _serv = serv;
        }

        [HttpGet]
        [Route("buscar-seguro/{cpf}")]
        public ActionResult GetSeguroCPF(string cpf)
        {
            try
            {
                var seguro = _serv.BuscarSeguro(cpf);

                return Ok(seguro);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao consultar o seguro para o cpf {cpf} : {ex.Message}");
            }
        }


        [HttpGet]
        [Route("buscar-seguros/{cpf}")]
        public ActionResult GetSegurosCPF(string cpf)
        {
            try
            {
                var seguro = _serv.BuscarSeguros(cpf);

                return Ok(seguro);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao consultar o seguro para o cpf {cpf} : {ex.Message}");
            }
        }


        [HttpGet]
        [Route("relatorio")]
        public ActionResult GetRelatorio()
        {
            try
            {
                var seguro = _serv.Relatorio();

                return Ok(seguro);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao consultar o relatório : {ex.Message}");
            }
        }


        [HttpPost]
        [Route("calcular-seguro-veiculo")]
        public ActionResult CriarLancamento([FromBody] CalculoSeguroVeiculoInput inputs)
        {
            try
            {
                double valorSeguro = _serv.CalcularSeguro(inputs);

                return Ok(valorSeguro);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao calcular o valor do seguro: {ex.Message}");
            }

        }

    }
}
