using EcoJardimProject.API.Services;
using EcoJardimProject.Domain.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoJardimProject.API.Controllers;

[Route("[controller]")]
[ApiController]
public class LoginController : Controller
{
    private readonly ILoginService _service;
    public LoginController(ILoginService usuariosService)
    {
        _service = usuariosService;
    }
    
    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<UsuarioToken>> Login([FromBody] LoginDTO usuario)
    {
        var token = await _service.Login(usuario);

        return Ok(token);
    }
}