using Mapster;
using UserManagement.Application.Exeptions;
using UserManagement.Application.Transaction.Interfaces;
using UserManagement.Application.Transaction.Requests;
using UserManagement.Application.Transaction.Responses;
using UserManagement.Domain.Transactions;

namespace UserManagement.Application.Transaction
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _uow;
        public TransactionService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> CreateAsync(CancellationToken cancellationToken, TransactionRequestPostModel transactionRequestModel)
        {
            if(transactionRequestModel.TransferredAmount <= 0)
            {
                throw new AmmountException("Transfered Ammount Exception");
            }
            var sender = await _uow.Customers.LoginAsync(cancellationToken, transactionRequestModel.CustomerLoginModel);
            var reciever = await _uow.Customers.GetAsync(cancellationToken, transactionRequestModel.ReceiverCustomerId);
            if(sender is null || reciever  is null)
            {
                throw new CustomerNotFoundException("Sender Or Reciever Not Found ESxception");
            }
            if(sender.Wallet < transactionRequestModel.TransferredAmount)
            {
                throw new AmmountException("Not Enough Money Exception");
            }
            sender.Wallet -= transactionRequestModel.TransferredAmount;
            reciever.Wallet += transactionRequestModel.TransferredAmount;
            await _uow.SaveChangesAsync(cancellationToken);
            var entity = new Transactionn
            {
                SenderCustomerId = sender.Id,
                ReceiverCustomerId = transactionRequestModel.ReceiverCustomerId,
                TransferredAmount = transactionRequestModel.TransferredAmount,
                DateOfTransfer = DateTime.Now
            };
            var result = await _uow.Transactions.CreateAsync(cancellationToken, entity);
            return result;
        }

        public async Task<List<TransactionResponseModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var entities = await _uow.Transactions.GetAllAsync(cancellationToken);
            if(entities is null)
            {
                throw new TransactionNotFoundException("Transactions Not Found Exception");
            }
            var result = entities.Adapt<List<TransactionResponseModel>>();
            return result;
        }
    }
}
