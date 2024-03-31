using Mapster;
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
            if (customerRequestModel.Wallet < 0)
            {
                throw new AmmountException("Ammount Exception");
            }
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
            if(entity == null)
            {
                throw new CustomerNotFoundException("Customer Not Found Exception");
            }
            var result = await _uow.Customers.DeleteAsync(cancellationToken, entity.Id);
            return result;
        }

      public async  Task<List<CustomerResponseModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var entities = await _uow.Customers.GetAllAsync(cancellationToken);
            if (entities == null)
            {
                throw new CustomerNotFoundException("Customer Not Found Exception");
            }
            var result = entities.Adapt<List<CustomerResponseModel>>();
            return result;
        }

      public async  Task<CustomerResponseModel> GetAsync(CancellationToken cancellationToken, int id)
        {
            var result = await _uow.Customers.GetAsync(cancellationToken,id);
            if (result == null)
            {
                throw new CustomerNotFoundException("Customer Not Found Exception");
            }
            return result.Adapt<CustomerResponseModel>();
        }
    }
}
