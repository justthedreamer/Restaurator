using System.Net;
using Core;
using Core.Exceptions;
using Core.Exceptions.User;
using Newtonsoft.Json;

namespace Web_API.Middleware;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var statusCode = HttpStatusCode.InternalServerError; // 500 if unexpected
        var message = "An unexpected error occurred.";

        switch (exception)
        {
            case BadRequestException:
                statusCode = HttpStatusCode.BadRequest; // 400
                message = exception.Message;
                break;
            case AuthorizeException:
                statusCode = HttpStatusCode.Unauthorized; // 401
                message = exception.Message;
                break;
            case ConflictException:
                statusCode = HttpStatusCode.Conflict; // 409
                message = exception.Message;
                break;
            case NotFoundException:
                statusCode = HttpStatusCode.NotFound; // 404
                message = exception.Message;
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var result = JsonConvert.SerializeObject(new
        {
            status = context.Response.StatusCode,
            title = statusCode.ToString(),
            detail = message
        });

        return context.Response.WriteAsync(result);
    }
}