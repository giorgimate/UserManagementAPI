using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using UserManagement.Application.Customers.Interfaces;
using UserManagement.Application.Customers.Requests;
using UserManagement.Domain.Customers;
using UserManagement.Persistence.Context;

namespace UserManagement.Infrastructure.Customers
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        const string SECRET_KEY = "tera";
        public CustomerRepository(UserManagementContext context) : base(context)
        {
            
        }

        public async Task<bool> CreateAsync(CancellationToken cancellationToken, Customer customer)
        {
            var password = GenerateHash(customer.Password + SECRET_KEY);
            customer.Password = password;
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
        public async Task<Customer> LoginAsync(CancellationToken cancellationToken, CustomerLoginModel loginModel)
        {
            var hashedPassword = GenerateHash(loginModel.Password + SECRET_KEY);
            var customer = await _dbSet.SingleOrDefaultAsync(u=>u.Email == loginModel.Email && u.Password == hashedPassword, cancellationToken);
            return customer;
        }
        public async Task<bool> Exists(CancellationToken cancellationToken, string email)
        {
            var result = await base.AnyAsync(cancellationToken, x=>x.Email == email);
            return result;
        }
        private string GenerateHash(string input)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                var bytes = Encoding.ASCII.GetBytes(input);
                var hashBytes = sha512.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }

                return sb.ToString();
            }
        }
    }
}
