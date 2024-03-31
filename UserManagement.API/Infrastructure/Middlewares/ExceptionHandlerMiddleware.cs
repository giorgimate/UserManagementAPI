using Newtonsoft.Json;
namespace UserManagement.API.Infrastructure.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);

            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var error = new ApiError(context, ex);
            var result = JsonConvert.SerializeObject(error);

            await LogExceptionToFile(ex);

            context.Response.Clear();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = error.Status.Value;

            await context.Response.WriteAsync(result);
        }
        private async Task LogExceptionToFile(Exception ex)
        {
            var exceptionLog = $"{Environment.NewLine}Logged from Middleware {Environment.NewLine}" +
                               $"Exception Type: {ex.GetType().Name}{Environment.NewLine}" +
                               $"Message: {ex.Message}{Environment.NewLine}" +
                               $"StackTrace: {ex.StackTrace}{Environment.NewLine}" +
                               $"Time: {DateTime.Now}{Environment.NewLine}";

            await File.AppendAllTextAsync("Exceptions.txt", exceptionLog);
        }
    }
}
