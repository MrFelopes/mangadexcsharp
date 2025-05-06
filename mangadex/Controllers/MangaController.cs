using Microsoft.AspNetCore.Mvc;
using mangadex.Services;
using mangadex.Models;


namespace mangadex.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MangaController(MangaService service) : ControllerBase
{
    [HttpGet("random")]
    public async Task<IActionResult> GetRandomManga()
    {
        var mangas = await service.BuscarMangaAsync();
        if (mangas == null || mangas.Count == 0)
            return NotFound("Nenhum mangá encontrado");

        var random = new Random();
        var escolhido = mangas [random.Next(mangas.Count)];
        return Ok(escolhido);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllMangas()
    {
        var mangas = await service.BuscarMangaAsync();

        if (mangas == null || mangas.Count == 0)
            return NotFound("Nenhum mangá encontrado.");

        var resultado = mangas.Select(m => new
        {
            id = m.Id,
            titulo = m.Attributes.ObterTitulo(),
            descricao = m.Attributes.ObterDescricao(),
            status = m.Attributes.Status,
            tipo = m.Type,
            classIndicativa = m.Attributes.ContentRating,
            linguaOriginal = m.Attributes.OriginalLanguage
        });
        return Ok(resultado);
    }
}
