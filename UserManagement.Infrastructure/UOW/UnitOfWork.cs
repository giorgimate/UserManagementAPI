using UserManagement.Application.Customers.Interfaces;
using UserManagement.Application.Transaction.Interfaces;
using UserManagement.Application;
using UserManagement.Persistence.Context;

public class UnitOfWork : IUnitOfWork
{
    protected readonly UserManagementContext _dbContext;


    public UnitOfWork(UserManagementContext dbContext, ITransactionRepository transactionsRepository, ICustomerRepository customerRepository)
    {
        _dbContext = dbContext;
        Transactions = transactionsRepository;
        Customers = customerRepository;
    }

    
    public ICustomerRepository Customers { get; }

    public ITransactionRepository Transactions  {get;}

    public void Dispose()
    {
        _dbContext.Dispose();
    }

    public void SaveChanges()
    {
        _dbContext.SaveChanges();
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
