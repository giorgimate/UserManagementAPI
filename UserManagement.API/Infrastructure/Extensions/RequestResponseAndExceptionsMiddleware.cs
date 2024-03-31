using UserManagement.API.Infrastructure.Middlewares;

namespace UserManagement.API.Infrastructure.Extensions
{
    public static class RequestResponseAndExceptionsMiddleware
    {
        public static IApplicationBuilder UseRequestResponseExceptionsLogging(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<RequestResponseLoggin>();
            builder.UseMiddleware<UserManagement.API.Infrastructure.Middlewares.ExceptionHandlerMiddleware>();
            return builder;
        }
    }
}
