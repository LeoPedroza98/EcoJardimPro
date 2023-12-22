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
public class ServicoController : MasterCrudController<Servico>
{
  private IServicoService _service;

  public ServicoController(ILogger<MasterCrudController<Servico>> logger, IServicoService service, string includePatch = "Status,Orcamento") : base(logger, service, includePatch)
  {
    _service = service;
  }
}