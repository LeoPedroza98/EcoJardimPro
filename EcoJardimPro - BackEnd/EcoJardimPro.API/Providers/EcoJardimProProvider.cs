﻿using EcoJardimPro.DATA.Interface;
using EcoJardimPro.DOMAIN.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;

namespace EcoJardimPro.API.Providers
{
    public class EcoJardimProProvider : IEcoJardimProProvider
    {
        public SessionAppModel SessionApp { get; }

        public EcoJardimProProvider(IHttpContextAccessor accessor)
        {

            try
            {
                if (accessor.HttpContext == null)
                    return;

                var excecoes = new string[] { "/api/autenticador/usuario" };

                if (excecoes.Contains(accessor.HttpContext.Request.Path.ToString()))
                    return;


                if ("/api/usuario" == accessor.HttpContext.Request.Path.ToString() && accessor.HttpContext.Request.Method == "POST")
                    return;

                var identity = accessor.HttpContext.User;

                SessionApp = new SessionAppModel(
                    long.Parse(identity.FindFirst(ClaimTypes.Upn).Value),
                    identity.FindFirst(ClaimTypes.NameIdentifier).Value,
                    identity.FindFirst(ClaimTypes.Role).Value,
                    identity.FindFirst(ClaimTypes.Name).Value
                );
            }
            catch (Exception)
            {
                accessor.HttpContext.Response.StatusCode = 500;
                accessor.HttpContext.Response.WriteAsync("Internal Server error");

                throw new InvalidOperationException("Internal Server error!");
            }
        }
    }
}
