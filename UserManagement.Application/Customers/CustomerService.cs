using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Customers.Interfaces;
using UserManagement.Application.Customers.Requests;
using UserManagement.Application.Customers.Respones;
using UserManagement.Application.Exeptions;
using UserManagement.Domain.Customers;

namespace UserManagement.Application.Customers
{
    public class CustomerService : ICustomerService
    {
        IUnitOfWork _uow;
        public CustomerService(IUnitOfWork uow)
        {
            _uow = uow;
        }
         public async Task<bool> CreateAsync(CancellationToken cancellationToken, CustomerRequestPostModel customerRequestModel)
        {
            var exists = await _uow.Customers.Exists(cancellationToken, customerRequestModel.Email);
            if (exists)
            {
                throw new CustomerAlreadyExistException("Customer Already Exist Exception");
            }
            var entity = customerRequestModel.Adapt<Customer>();
            var result = await _uow.Customers.CreateAsync(cancellationToken, entity);
            return result;
        }

        public async Task<bool> DeleteAsync(CancellationToken cancellationToken, int id)
        {
            var entity = await _uow.Customers.GetAsync(cancellationToken,id);
            var result = await _uow.Customers.DeleteAsync(cancellationToken, entity.Id);
            return result;
        }

      public async  Task<List<CustomerResponseModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var entities = await _uow.Customers.GetAllAsync(cancellationToken);
            var result = entities.Adapt<List<CustomerResponseModel>>();
            return result;
        }

      public async  Task<CustomerResponseModel> GetAsync(CancellationToken cancellationToken, int id)
        {
            var result = await _uow.Customers.GetAsync(cancellationToken,id);
            return result.Adapt<CustomerResponseModel>();
        }
    }
}
