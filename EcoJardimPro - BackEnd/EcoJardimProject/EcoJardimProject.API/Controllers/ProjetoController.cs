using EcoJardimProject.API.Services;
using EcoJardimProject.Data.ControllerBase;
using EcoJardimProject.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoJardimProject.API.Controllers;

[Route("[controller]")]
[ApiController]
public class ProjetoController : MasterCrudController<Projeto>
{
    private IProjetoService _service;

    public ProjetoController(ILogger<MasterCrudController<Projeto>> logger, IProjetoService service, string includePatch = "Status,Cliente") : base(logger, service, includePatch)
    {
        _service = service;
    }

    [HttpGet("AutoComplete")]
    public async Task<ActionResult<List<Projeto>>> AutoComplete(string q)
    {
        if (string.IsNullOrEmpty(q))
            return BadRequest("Filtro não informado!");

        try
        {
            var lista = await _service.AutoComplete(q);

            return Ok(lista);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                $"Algum erro ocorreu! {e.Message} - {e.InnerException?.Message}");
        }
    }
}