## Treino com a API do mangadex

Para utilizar, rodar em localhost e abrir em /api/manga/random. Um mangá aleatório será retornado como JSON.
Dois parâmetros estão sendo aplicados por padrão: limit = "100" (limitando as requisições em 100 por vez) e availableTranslatedChapters[] = "pt-br" (Apenas mangás que possuem capítulos em português brasileiro serão retornados). Os parâmetros podem ser alterados em MangaController.cs
