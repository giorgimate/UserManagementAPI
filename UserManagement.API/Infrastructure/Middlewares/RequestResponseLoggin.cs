namespace UserManagement.API.Infrastructure.Middlewares
{
    public class RequestResponseLoggin
    {
        private readonly RequestDelegate _next;

        public RequestResponseLoggin(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await LogRequest(context.Request);
            await LogResponse(context.Response);

            await _next(context);
        }

        private async Task LogRequest(HttpRequest request)
        {
            var toLog = $"{Environment.NewLine}Logged from MIddleware {Environment.NewLine}" +
            $"IP = {request.HttpContext.Connection.RemoteIpAddress}{Environment.NewLine}" +
            $"Address = {request.Scheme}{Environment.NewLine}" +
            $"Method = {request.Method}{Environment.NewLine}" +
            $"Path = {request.Path}{Environment.NewLine}" +
            $"IsSescured = {request.IsHttps}{Environment.NewLine}" +
            $"QueryString = {request.QueryString}{Environment.NewLine}" +
            $"Time = {DateTime.Now}{Environment.NewLine}";

            await File.AppendAllTextAsync("Request.txt", toLog);
        }

        private async Task LogResponse(HttpResponse response)
        {
            var toLog = $"{Environment.NewLine}Logged from Middleware {Environment.NewLine}" +
                $"Status code: {response.StatusCode}{Environment.NewLine}" +
                $"Headers: {string.Join(",", response.Headers)}{Environment.NewLine}" +
                $"Body: {response.Body}{Environment.NewLine}" +
                $"Time: {DateTime.Now}{Environment.NewLine}";

            await File.AppendAllTextAsync("Response.txt", toLog);
        }
    }
}
