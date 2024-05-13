using EcoJardimProject.API.Services;
using EcoJardimProject.Domain.DTOs;
using EcoJardimProject.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoJardimProject.API.Controllers;

[Route("[controller]")]
[ApiController]
public class UsuarioController : Controller
{
    private readonly IUsuarioService _service;

    public UsuarioController(IUsuarioService service)
    {
        _service = service;
    }
    
    
    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<Usuario>> Post([FromBody] UsuarioDTO usuario)
    {
        await _service.Create(usuario);
        return Ok();
    }
}