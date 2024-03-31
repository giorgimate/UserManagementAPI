using UserManagement.Application.Customers.Requests;
using UserManagement.Domain.Customers;

namespace UserManagement.Application.Customers.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync(CancellationToken cancellationToken);
        Task<Customer> GetAsync(CancellationToken cancellationToken, int customerId);
        Task<Customer> LoginAsync(CancellationToken cancellationToken, CustomerLoginModel loginModel);
        Task<bool> CreateAsync(CancellationToken cancellationToken, Customer customer);
        Task<bool> DeleteAsync(CancellationToken cancellationToken, int customerId);
        Task<bool> Exists(CancellationToken cancellationToken, string email);
    }
}
