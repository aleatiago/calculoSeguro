
<h1>Projeto para calculo de seguro de veiculos</h1>

<h2>App.Seguros</h2>
<p>Aplicativo web api com .net core 2, os dados estão sendo persistidos em banco de dados oracle com entity framework</p>
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



<h2>Teste.Seguros</h2>
<p>Aplicativo MS Teste para cobertura de teste do App.Teste</p>

<h6>Metodos de teste:</h6>
<p>ValorNaoPodeSerNegativo()</p>
<p>TaxaDeveSer3eLucro5()</p>


<h2>ClientApp</h2>
<p>Aplicativo Angular 8</p>
<p>Para a busca dos veiculos foi utilizada a api da tabela fipe http://fipeapi.appspot.com/</p>
