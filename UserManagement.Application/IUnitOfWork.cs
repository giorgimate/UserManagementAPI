using UserManagement.Application.Customers.Interfaces;
using UserManagement.Application.Transaction.Interfaces;

namespace UserManagement.Application
{
    public interface IUnitOfWork : IDisposable
    {
         ICustomerRepository Customers { get; }
         ITransactionRepository Transactions { get; }
        void SaveChanges();
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
