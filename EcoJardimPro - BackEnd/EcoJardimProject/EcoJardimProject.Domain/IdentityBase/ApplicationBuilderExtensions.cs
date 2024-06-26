﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoJardimProject.Domain.IdentityBase
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseConfiguracaoSessao(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ConfiguracaoSessaoMiddleware>();

        }

        public class ConfiguracaoSessaoMiddleware
        {
            private readonly RequestDelegate _proximo;

            public ConfiguracaoSessaoMiddleware(RequestDelegate next)
            {
                _proximo = next;
            }

            public async Task InvokeAsync(HttpContext context, ISessaoUsuario sessao)
            {
                if (context.User.Identities.Any(id => id.IsAuthenticated))
                {
                    sessao.UsuarioId = context.User.Claims.FirstOrDefault(x => x.Type == "userid").Value;
                    sessao.UserName = context.User.Claims.FirstOrDefault(x => x.Type == "username").Value;
                    sessao.Roles = context.User.Claims.Where(x => x.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Select(x => x.Value).ToList();
                }

                await _proximo.Invoke(context);
            }

        }
    }
}
