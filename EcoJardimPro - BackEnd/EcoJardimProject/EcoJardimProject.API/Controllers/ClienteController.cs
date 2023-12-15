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
}