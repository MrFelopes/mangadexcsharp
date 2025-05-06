## Treino com a API do Mangadex

### O que é?
Nada demais, apenas um pequeno projeto de API em C# que consome a API do Mangadex. Estou trabalhando nele no meu tempo livre como uma forma de aprender C# :)

### Como utilizar?
Para utilizar, rodar em localhost. Por padrão, o projeto roda na porta <b>5212</b>. Nesse caso, o caminho para o projeto seria localhost:5212/api/manga/<b>endpoint</b>

### Endpoints
No momento, o projeto possui apenas 2 endpoints:
<br>
<br>
<b>/random:</b> Retorna um mangá aleatório;
<br>
<b>/all:</b> Retorna o máximo de mangás possíveis (<b>Atenção com esse endpoint,</b> pois caso os parâmetros forem alterados e o limite máximo de mangás retornáveis seja muito alto, o sistema pode sobrecarregar, ou a API do mangadex pode te bloquear temporariamente como medida anti-DDOS).

### Parâmetros
Dois parâmetros estão sendo aplicados por padrão: 
<br>
<br>
<b>limit = "50"</b> (limitando as requisições à API do Mangadex a 50 por vez);
<br>
<b>availableTranslatedChapters[] = "pt-br"</b> (Apenas mangás que possuem capítulos em português brasileiro serão retornados). 
<br>
<br>
Os parâmetros podem ser alterados em <b>MangaService.cs</b>.
