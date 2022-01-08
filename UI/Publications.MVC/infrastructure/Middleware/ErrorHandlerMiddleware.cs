namespace Publications.MVC.infrastructure.Middleware;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlerMiddleware> _logger;

    public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
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
            HandlerException(ex, context);
            throw;
        }
    }

    private void HandlerException(Exception err, HttpContext context)
    {
        _logger.LogError(err, "Ошибка при обработке запроса к {0}", context.Request.Path);
    }
}
