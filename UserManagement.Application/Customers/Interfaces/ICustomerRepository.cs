using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Customers;

namespace UserManagement.Application.Customers.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync(CancellationToken cancellationToken);
        Task<Customer> GetAsync(CancellationToken cancellationToken, int customerId);
        Task<bool> CreateAsync(CancellationToken cancellationToken, Customer customer);
        Task<bool> DeleteAsync(CancellationToken cancellationToken, int customerId);
    }
}
