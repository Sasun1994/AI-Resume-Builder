public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            // Call the next middleware in the pipeline
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            // Handle exception (log it, return custom error response, etc.)
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        // Example: Log exception and return a custom response
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        var response = new { message = "Internal Server Error", details = exception.Message };
        return context.Response.WriteAsJsonAsync(response);
    }
}
