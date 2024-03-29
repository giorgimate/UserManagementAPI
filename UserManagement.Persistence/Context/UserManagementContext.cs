using Microsoft.EntityFrameworkCore;
using UserManagement.Domain;
using UserManagement.Domain.Customers;
using UserManagement.Domain.Transactions;

namespace UserManagement.Persistence.Context
{
    public class UserManagementContext : DbContext
    {
        public UserManagementContext(DbContextOptions<UserManagementContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transactionn> Transactions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transactionn>()
                .HasOne(t => t.ReceiverCustomer)
                .WithMany(c => c.ReceivedTransactions)
                .HasForeignKey(t => t.ReceiverCustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transactionn>()
                .HasOne(t => t.SenderCustomer)
                .WithMany(c => c.SentTransactions)
                .HasForeignKey(t => t.SenderCustomerId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
