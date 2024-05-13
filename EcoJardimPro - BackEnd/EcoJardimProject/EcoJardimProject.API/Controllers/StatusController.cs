using EcoJardimProject.API.Services;
using EcoJardimProject.Data.ControllerBase;
using EcoJardimProject.Data.ServicesBase;
using EcoJardimProject.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoJardimProject.API.Controllers;

[Route("[controller]")]
[ApiController]
public class StatusController : MasterQueryController<Status>
{
    private IStatusService _service;

    public StatusController(ILogger<MasterQueryController<Status>> logger, IStatusService service) : base(logger, service)
    {
        service = _service;
    }

      [HttpGet("AutoComplete")]
    public async Task<ActionResult<List<Status>>> AutoComplete(string q)
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