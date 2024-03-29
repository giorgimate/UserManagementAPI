using UserManagement.Domain.Transactions;

namespace UserManagement.Application.Transaction.Interfaces
{
    public interface ITransactionRepository
    {
        Task<List<Transactionn>> GetAllAsync(CancellationToken cancellationToken);
        Task<bool> CreateAsync(CancellationToken cancellationToken, Transactionn transaction);
    }
}
