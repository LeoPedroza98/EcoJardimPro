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
public class OrcamentoController : MasterCrudController<Orcamento>
{
   private IOrcamentoService _service;

   public OrcamentoController(ILogger<MasterCrudController<Orcamento>> logger, IOrcamentoService service, string includePatch = "Projeto,Servicos") : base(logger, service, includePatch)
   {
      _service = service;
   }

    [HttpGet("AutoComplete")]
    public async Task<ActionResult<List<Orcamento>>> AutoComplete(string q)
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