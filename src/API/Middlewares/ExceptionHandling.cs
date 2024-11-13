namespace ProductApp.API.Middlewares;

public class ExceptionHandling
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public ExceptionHandling(RequestDelegate next, ILogger<ExceptionHandling> logger)
    {
        _next = next;
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            ErrorResponse error = await HandleExceptionAsync(httpContext, ex);

            _logger.LogError(ex, $"Request {httpContext.Request?.Method}: {httpContext.Request?.Path.Value} failed Error: {@error}", error);
        }
    }
    private async Task<ErrorResponse> HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode statusCode = HttpStatusCode.InternalServerError, string? message = null)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;
        Console.WriteLine(context.Response.StatusCode);
        ErrorResponse response = new()
        {
            Message = message ?? exception.Message,
        };
        string json = JsonConvert.SerializeObject(response, new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        });
        await context.Response.WriteAsync(json);
        return response;
    }
}
public static class ExceptionHandlerMiddelwareExtensions
{
    public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandling>();
    }
}

