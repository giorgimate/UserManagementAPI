using UserManagement.Application.Transaction.Requests;
using UserManagement.Application.Transaction.Responses;

namespace UserManagement.Application.Transaction.Interfaces
{
    public interface ITransactionService
    {
        Task<List<TransactionResponseModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<bool> CreateAsync(CancellationToken cancellationToken, TransactionRequestPostModel transactionRequestModel);
    }
}
