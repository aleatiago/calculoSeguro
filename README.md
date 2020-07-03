
<h1>Projeto para calculo de seguro de veiculos</h1>
<h4>URLS:</h4>
<h6>POST:</h6>
/api/v1/seguro-veiculo/calcular-seguro-veiculo<br />
body:
<blockquote>
{<br />
	"nome": "Alexandre",<br />
	"cpf": "11122233399",<br />
	"idade": "31",<br />
	"marca_modelo": "Fiat-GranSiena",<br />
   "valorVeiculo" : "40000.00"<br />
}
</blockquote>
========================================<br />
<h6>GET:</h6>
/api/v1/seguro-veiculo/relatorio<br />
/api/v1/seguro-veiculo/buscar-seguro/{cpf}<br />
/api/v1/seguro-veiculo/buscar-seguros/{cpf}
