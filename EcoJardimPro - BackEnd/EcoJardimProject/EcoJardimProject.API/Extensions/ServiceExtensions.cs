using EcoJardimProject.Data.Context;
using EcoJardimProject.Domain.IdentityBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using EcoJardimProject.API.Services;

namespace EcoJardimProject.API.Extensions
{
    public static class ServiceExtension
    {

        public static void AddInjections(this IServiceCollection services)
        {
            services.AddScoped<ISessaoUsuario, SessaoUsuario>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<DbContext, EcoJardimProjectContext>();
            services.AddSingleton<TokenMemoryRepository>();
            services.AddTransient<TokenValidationMiddleware>();
        }

    }
}
