using EcoJardimPro.API.Models.Shared;
using EcoJardimPro.SERVICE.Interface;
using EcoJardimPro.UTIL.Exceptions;
using EcoJardimPro.UTIL.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EcoJardimPro.API.Controllers
{
    public class AutenticadorController : MasterBaseController
    {
        private readonly IAutenticadorService _autenticadorService;
        public AutenticadorController(IAutenticadorService autenticadorService)
        {
            _autenticadorService = autenticadorService;
        }

        [HttpPost("Usuario")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            try
            {
                var retorno = await _autenticadorService.Login(model.Login, model.Senha);
                return Ok(retorno);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }
        }
    }
}
