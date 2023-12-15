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

   public OrcamentoController(ILogger<MasterCrudController<Orcamento>> logger, IOrcamentoService service, string includePatch = "Projeto,Servico") : base(logger, service, includePatch)
   {
      _service = service;
   }
}