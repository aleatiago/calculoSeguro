Projeto para calculo de seguro de veiculos

URLS:

POST:
api/v1/seguro-veiculo/calcular-seguro-veiculo
body:
{
	"nome": "Alexandre",
	"cpf": "11122233399",
	"idade": "31",
	"marca_modelo": "Fiat-GranSiena",
   "valorVeiculo" : "40000.00"
}

========================================
GET:
/api/v1/seguro-veiculo/relatorio
api/v1/seguro-veiculo/buscar-seguro/{cpf}
api/v1/seguro-veiculo/buscar-seguros/{cpf}
