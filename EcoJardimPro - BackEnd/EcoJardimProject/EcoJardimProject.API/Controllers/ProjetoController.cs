using EcoJardimProject.API.Services;
using EcoJardimProject.Data.ControllerBase;
using EcoJardimProject.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoJardimProject.API.Controllers;

[Route("[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
public class ProjetoController : MasterCrudController<Projeto>
{
    private IProjetoService _service;

    public ProjetoController(ILogger<MasterCrudController<Projeto>> logger, IProjetoService service, string includePatch = "Status,Cliente") : base(logger, service, includePatch)
    {
        _service = service;
    }
}