using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Customers.Requests;
using UserManagement.Application.Customers.Respones;

namespace UserManagement.Application.Customers.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerResponseModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<CustomerResponseModel> GetAsync(CancellationToken cancellationToken,int id);
        Task<bool> CreateAsync(CancellationToken cancellationToken, CustomerRequestPostModel customerRequestModel);
        Task<bool> DeleteAsync(CancellationToken cancellationToken, int id);
    }
}
