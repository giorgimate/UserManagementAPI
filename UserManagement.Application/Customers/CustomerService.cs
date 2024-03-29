using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Customers.Interfaces;
using UserManagement.Application.Customers.Requests;
using UserManagement.Application.Customers.Respones;
using UserManagement.Domain.Customers;

namespace UserManagement.Application.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }
         public async Task<bool> CreateAsync(CancellationToken cancellationToken, CustomerRequestPostModel customerRequestModel)
        {
            var entity = customerRequestModel.Adapt<Customer>();
            var result = await _repository.CreateAsync(cancellationToken, entity);
            return result;
        }

        public async Task<bool> DeleteAsync(CancellationToken cancellationToken, int id)
        {
            var entity = await _repository.GetAsync(cancellationToken,id);
            var result = await _repository.DeleteAsync(cancellationToken, entity.Id);
            return result;
        }

      public async  Task<List<CustomerResponseModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync(cancellationToken);
            var result = entities.Adapt<List<CustomerResponseModel>>();
            return result;
        }

      public async  Task<CustomerResponseModel> GetAsync(CancellationToken cancellationToken, int id)
        {
            var result = await _repository.GetAsync(cancellationToken,id);
            return result.Adapt<CustomerResponseModel>();
        }
    }
}
