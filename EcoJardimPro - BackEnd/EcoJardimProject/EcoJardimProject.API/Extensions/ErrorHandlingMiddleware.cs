using System.Text.Json;
using EcoJardimProject.Utils.Exceptions;

namespace EcoJardimProject.API.Extensions;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
    {
        var code = StatusCodes.Status500InternalServerError;
        switch (ex)
        {
            case BadRequestException exception:
                code = StatusCodes.Status400BadRequest;
                break;
            case NotFoundException exception:
                code = StatusCodes.Status404NotFound;
                break;
            case UnauthorizedException exception:
                code = StatusCodes.Status401Unauthorized;
                break;
            case ArgumentException exception:
                code = StatusCodes.Status404NotFound;
                break;
        }

        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = code;
        //
        string message = ex.Message;
        return httpContext.Response.WriteAsync(JsonSerializer.Serialize(new { StatusCode = code.ToString(), Mensagem = message}));
    }
}