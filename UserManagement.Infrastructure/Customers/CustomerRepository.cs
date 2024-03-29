using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using UserManagement.Application.Customers.Interfaces;
using UserManagement.Domain.Customers;
using UserManagement.Persistence.Context;

namespace UserManagement.Infrastructure.Customers
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(UserManagementContext context) : base(context)
        {
            
        }

        public async Task<bool> CreateAsync(CancellationToken cancellationToken, Customer customer)
        {
            var result = await base.CreateAsync(cancellationToken, customer);
            return result;
        }

        public async Task<bool> DeleteAsync(CancellationToken cancellationToken, int customerId)
        {
            var result = await base.DeleteAsync(cancellationToken, customerId);
            return result;
        }

        public async Task<List<Customer>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Set<Customer>()
                .Include(trn=>trn.SentTransactions)
                .Include(trn => trn.ReceivedTransactions)
                .Where(x=>x.Status == Domain.Status.Active)
                .ToListAsync(cancellationToken);
        }

        public async Task<Customer> GetAsync(CancellationToken cancellationToken, int customerId)
        {
            return await _context.Set<Customer>()
                            .Include(trn => trn.SentTransactions)
                            .Include(trn => trn.ReceivedTransactions)
                            .FirstOrDefaultAsync(cust => cust.Id == customerId && cust.Status == Domain.Status.Active,cancellationToken);
        }
        public async Task<bool> Exists(CancellationToken cancellationToken, string email)
        {
            var result = await base.AnyAsync(cancellationToken, x=>x.Email == email);
            return result;
        }
    }
}
