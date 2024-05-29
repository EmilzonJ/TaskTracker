using System.Net;
using System.Text.Json;
using Application.Exceptions;

namespace Web.Middlewares;

public class ErrorHandlerMiddlerware(RequestDelegate next, ILogger<ErrorHandlerMiddlerware> logger)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception, logger);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception, ILogger logger)
    {
        ExceptionResponse response = new();
        switch (exception)
        {
            case UnauthorizedException unauthorizedException:
                logger.LogInformation(exception, "----------------------UNAUHORIZED ERROR TYPE---------------------");
                response.Errors = unauthorizedException.Errors;
                response.StatusCode = (int) HttpStatusCode.Unauthorized;
                response.Title = "Unauthorized";
                context.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
                break;

            case NotFoundException notFoundException:
                logger.LogError(exception, "----------------------NOT FOUND ERROR TYPE---------------------");
                response.Errors = notFoundException.Errors;
                response.StatusCode = (int) HttpStatusCode.NotFound;
                response.Title = "Not Found";
                context.Response.StatusCode = (int) HttpStatusCode.NotFound;
                break;

            case CommandValidationException commandValidationException:
                logger.LogError(exception, "----------------------COMMAND VALIDATION ERROR TYPE---------------------");
                response.Errors = commandValidationException.Errors;
                response.StatusCode = (int) HttpStatusCode.BadRequest;
                response.Title = "Parameters validation failed";
                context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                break;

            case not null:
                logger.LogError(exception, "----------------------SERVER ERROR TYPE---------------------");
                response.Errors = new[] {"Ha ocurrido un error en el servidor"};
                response.StatusCode = (int) HttpStatusCode.InternalServerError;
                response.Title = "Internal Server Error";
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                break;
        }

        context.Response.ContentType = "application/json";

        var result = JsonSerializer.Serialize(response);
        await context.Response.WriteAsync(result);
    }
}
