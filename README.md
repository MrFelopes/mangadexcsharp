## Treino com a API do mangadex

### Como utilizar?
Para utilizar, rodar em localhost. Por padrão, o projeto roda na porta <b>5212</b>.

### Endpoints
No momento, o projeto possui apenas 2 endpoits:
<b>/random:</b> Retorna um mangá aleatório;
<b>/all:</b> Retorna o máximo de mangás possíveis (<b>Atenção com esse endpoint,</b> pois caso os parâmetros forem alterados e o limite máximo de mangás retornáveis seja muito alto, o sistema pode sobrecarregar, ou a API do mangadex pode te bloquear temporariamente como medida anti-DDOS).

### Parâmetros
Dois parâmetros estão sendo aplicados por padrão: 

<b>limit = "50"</b> (limitando as requisições à API do MangaDex a 50 por vez);
<b>availableTranslatedChapters[] = "pt-br"</b> (Apenas mangás que possuem capítulos em português brasileiro serão retornados). 

Os parâmetros podem ser alterados em <b>MangaService.cs</b>.
