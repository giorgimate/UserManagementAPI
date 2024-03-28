using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagement.Domain.Customers;

namespace UserManagement.Persistence.Configurations
{
    public class CustomerConfiguration
    {
        public  void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e=> e.FirstName).IsRequired();
            builder.Property(e=> e.LastName).IsRequired();
        }
    }
}
