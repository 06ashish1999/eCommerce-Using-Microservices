
namespace eCommerce.API.Middlewares;

public class ExceptionHandling : IMiddleware
{
    private readonly ILogger<ExceptionHandling> _logger;
    public ExceptionHandling(ILogger<ExceptionHandling> logger)
    {
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception externalException)
        {
            _logger.LogError($"error type: {externalException.GetType().ToString()}, Messgae: {externalException.Message}");

            bool isInnerException = externalException.InnerException != null;

            if (isInnerException)
            {
                _logger.LogError($"inner exception type: {externalException.InnerException?.GetType().ToString()}, " +
                                 $"Message: {externalException.InnerException?.Message}");
            }
            
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new { externalExceptionType = externalException.GetType().ToString(),
                                                          externalExceptionMessage = externalException.Message,
                                                          internalExceptionType = isInnerException? externalException.InnerException?.GetType().ToString(): "No Inner exception",
                                                          internalExceptionMessage = isInnerException? externalException.InnerException?.Message: "No Inner Exception"
            });
        }
    }
}

public static class ExceptionHandlingExtension
{
    public static IApplicationBuilder HandleExceptionsIfAny(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionHandling>();
    }
}
