using UserManagement.Application;
using UserManagement.Application.Customers;
using UserManagement.Application.Customers.Interfaces;
using UserManagement.Application.Transaction;
using UserManagement.Application.Transaction.Interfaces;
using UserManagement.Infrastructure.Customers;
using UserManagement.Infrastructure.Transactions;

namespace UserManagement.API.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService,CustomerService>();
            services.AddScoped<ICustomerRepository,CustomerRepository>();

            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
