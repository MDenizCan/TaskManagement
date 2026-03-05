using System.Net;
using System.Text.Json;

namespace TaskManagement.API.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        int statusCode;
        string errorType;

        switch (exception)
        {
            case ArgumentException:
            case InvalidOperationException:
                statusCode = (int)HttpStatusCode.BadRequest;       // 400
                errorType  = "Bad Request";
                _logger.LogWarning(exception, "Client error: {Message}", exception.Message);
                break;

            case KeyNotFoundException:
                statusCode = (int)HttpStatusCode.NotFound;         // 404
                errorType  = "Not Found";
                _logger.LogWarning(exception, "Resource not found: {Message}", exception.Message);
                break;

            case UnauthorizedAccessException:
                statusCode = (int)HttpStatusCode.Unauthorized;     // 401
                errorType  = "Unauthorized";
                _logger.LogWarning(exception, "Unauthorized: {Message}", exception.Message);
                break;

            default:
                // Hata mesajı "not found" veya "already assigned" gibi iş kuralı hataları içeriyorsa 400 döndür
                if (exception.Message.Contains("not found", StringComparison.OrdinalIgnoreCase) ||
                    exception.Message.Contains("already", StringComparison.OrdinalIgnoreCase) ||
                    exception.Message.Contains("not assigned", StringComparison.OrdinalIgnoreCase))
                {
                    statusCode = exception.Message.Contains("not found", StringComparison.OrdinalIgnoreCase)
                        ? (int)HttpStatusCode.NotFound
                        : (int)HttpStatusCode.BadRequest;
                    errorType = statusCode == 404 ? "Not Found" : "Bad Request";
                    _logger.LogWarning(exception, "Business rule violation: {Message}", exception.Message);
                }
                else
                {
                    statusCode = (int)HttpStatusCode.InternalServerError;  // 500
                    errorType  = "Internal Server Error";
                    _logger.LogError(exception, "Unhandled exception: {Message}", exception.Message);
                }
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode  = statusCode;

        var response = new
        {
            statusCode,
            errorType,
            message = exception.Message
        };

        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        return context.Response.WriteAsync(JsonSerializer.Serialize(response, options));
    }
}
