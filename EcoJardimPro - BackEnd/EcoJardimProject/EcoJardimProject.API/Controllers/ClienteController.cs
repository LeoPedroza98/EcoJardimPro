using EcoJardimProject.API.Services;
using EcoJardimProject.Data.ControllerBase;
using EcoJardimProject.Data.ServicesBase;
using EcoJardimProject.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EcoJardimProject.API.Controllers;

public class ClienteController : MasterCrudController<Cliente>
{
    private IClienteService _service;


    public ClienteController(ILogger<MasterCrudController<Cliente>> logger, IClienteService service, string includePatch = "") : base(logger, service, includePatch)
    {
        _service = service;
    }
}