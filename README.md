
<h1>Projeto para cálculo de seguro de veículos</h1>

<h2>App.Seguros</h2>
<p>Aplicativo web api com .net core 2</p>
<p>Os dados estão sendo persistidos no banco de dados Oracle Database Express Edition (XE) Release 11.2.0.2.0 (11gR2) com Entity Framework</p>
<p>Para a arquitetura do projeto foi utilizado DDD</p>
<p>A politica de CORS está para aceitar informações de qualquer site, para facilitar o exemplo no ClientApp</p>
<h4>URLS:</h4>
<h6>POST:</h6>
/api/v1/seguro-veiculo/calcular-seguro-veiculo<br />
body:
<blockquote>
{<br />
CPF: "33544839890"<br />
Idade: "31"<br />
Marca: "Fiat"<br />
Modelo: "2017"<br />
Nome: "Alexandre Araujo Tiago"<br />
ValorVeiculo: " 32701.00"<br />
Veiculo: "MOBI WAY 1.0 Fire Flex 5p."<br />
}
</blockquote>
========================================<br />
<h6>GET:</h6>
/api/v1/seguro-veiculo/relatorio-media<br />
/api/v1/seguro-veiculo/todos-seguros<br />
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
