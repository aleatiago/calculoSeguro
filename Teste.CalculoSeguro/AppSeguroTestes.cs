using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.Seguro.Models.Inputs;
using App.Seguro.Service;
using Moq;
using App.Seguro.Infra.Repository;
using App.Seguro.Models;

namespace Teste.Seguro
{
    [TestClass]
    public class AppSeguroTestes
    {

        [TestMethod]
        public void ValorNaoPodeSerNegativo()
        {
            CalculoSeguroVeiculoInput input = new CalculoSeguroVeiculoInput();
            input.ValorVeiculo = -10000;
            double expect = 0;

            var mockRepo = new Mock<ICalculoSeguroVeiculoRepository>();
            mockRepo.Setup(x => x.CriarCalculoSeguro(new CalculoSeguroVeiculo())).Returns(true);
            SeguroVeiculoService service = new SeguroVeiculoService(mockRepo.Object);

            double v_seguro = service.CalcularSeguro(input);

            Assert.AreEqual(expect, v_seguro,"Valor n�o pode ser negativo");
        }


        [TestMethod]
        public void TaxaDeveSer3eLucro5()
        {
            CalculoSeguroVeiculoInput input = new CalculoSeguroVeiculoInput();
            input.ValorVeiculo = 10000;
            double expect = 270.375;

            var mockRepo = new Mock<ICalculoSeguroVeiculoRepository>();
            mockRepo.Setup(x => x.CriarCalculoSeguro(new CalculoSeguroVeiculo())).Returns(true);
            SeguroVeiculoService service = new SeguroVeiculoService(mockRepo.Object);

            double v_seguro = service.CalcularSeguro(input);

            Assert.AreEqual(expect, v_seguro, "taxa deve ser 3 e lucro 5");
        }


    }
}
