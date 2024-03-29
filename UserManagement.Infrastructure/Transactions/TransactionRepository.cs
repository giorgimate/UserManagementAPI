using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using UserManagement.Application.Transaction.Interfaces;
using UserManagement.Domain.Customers;
using UserManagement.Domain.Transactions;
using UserManagement.Persistence.Context;

namespace UserManagement.Infrastructure.Transactions
{
    public class TransactionRepository : BaseRepository<Transactionn>, ITransactionRepository
    {
        public TransactionRepository(UserManagementContext context) :base(context)
        {
            
        }

        public async Task<bool> CreateAsync(CancellationToken cancellationToken, Transactionn transaction)
        {
            var result = await base.CreateAsync(cancellationToken, transaction);
            return result;
        }

        public async Task<List<Transactionn>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Set<Transactionn>()
               .Include(trn => trn.SenderCustomer)
               .Include(trn => trn.ReceiverCustomer)
               .Where(x => x.Status == Domain.Status.Active)
               .ToListAsync(cancellationToken);
        }
    }
}
