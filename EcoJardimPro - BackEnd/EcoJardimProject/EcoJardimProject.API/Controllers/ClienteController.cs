using EcoJardimProject.API.Services;
using EcoJardimProject.Data.ControllerBase;
using EcoJardimProject.Data.ServicesBase;
using EcoJardimProject.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoJardimProject.API.Controllers;

[Route("[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
public class ClienteController : MasterCrudController<Cliente>
{
    private IClienteService _service;


    public ClienteController(ILogger<MasterCrudController<Cliente>> logger, IClienteService service, string includePatch = "Projetos") : base(logger, service, includePatch)
    {
        _service = service;
    }

    [HttpGet("AutoComplete")]
    public async Task<ActionResult<List<Cliente>>> AutoComplete(string q)
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