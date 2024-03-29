using UserManagement.Application.Customers;
using UserManagement.Application.Customers.Interfaces;
using UserManagement.Infrastructure.Customers;

namespace UserManagement.API.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService,CustomerService>();
            services.AddScoped<ICustomerRepository,CustomerRepository>();
        }
    }
}
