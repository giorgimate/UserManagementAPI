using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Customers.Respones;
using UserManagement.Application.Transaction.Interfaces;
using UserManagement.Application.Transaction.Requests;
using UserManagement.Application.Transaction.Responses;
using UserManagement.Domain.Customers;
using UserManagement.Domain.Transactions;

namespace UserManagement.Application.Transaction
{
    public class TransactionService : ITransactionService
    {
        IUnitOfWork _uow;
        public TransactionService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> CreateAsync(CancellationToken cancellationToken, TransactionRequestPostModel transactionRequestModel)
        {
            // check if sender and reciev customers are 
            var entity = transactionRequestModel.Adapt<Transactionn>();

            var result = await _uow.Transactions.CreateAsync(cancellationToken, entity);
            return result;
        }

        public async Task<List<TransactionResponseModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var entities = await _uow.Transactions.GetAllAsync(cancellationToken);
            var result = entities.Adapt<List<TransactionResponseModel>>();
            return result;
        }
    }
}
