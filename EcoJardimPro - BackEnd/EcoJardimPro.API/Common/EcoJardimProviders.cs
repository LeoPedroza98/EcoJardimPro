using EcoJardimPro.Data.Common;
using EcoJardimPro.Domain.Extensions;
using System.Security.Claims;

namespace EcoJardimPro.API.Common
{
    public class EcoJardimProviders : IEcoJardimProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SessionAppModel SessionApp { get; }

        public EcoJardimProviders(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            try
            {
                if (httpContextAccessor.HttpContext == null)
                    return;

                var excecoes = new string[] { "/api/autenticador/usuario" };

                if (excecoes.Contains(httpContextAccessor.HttpContext.Request.Path.ToString()))
                    return;


                if ("/api/usuario" == httpContextAccessor.HttpContext.Request.Path.ToString() && httpContextAccessor.HttpContext.Request.Method == "POST")
                    return;

                var identity = httpContextAccessor.HttpContext.User;

                SessionApp = new SessionAppModel(
                    long.Parse(identity.FindFirst(ClaimTypes.Upn).Value),
                    identity.FindFirst(ClaimTypes.NameIdentifier).Value,
                    identity.FindFirst(ClaimTypes.Role).Value,
                    identity.FindFirst(ClaimTypes.Name).Value
                );
            }

            catch (Exception)
            {
                httpContextAccessor.HttpContext.Response.StatusCode = 500;
                httpContextAccessor.HttpContext.Response.WriteAsync("Internal Server error");

                throw new InvalidOperationException("Internal Server error!");
            }
        }

    }
}
