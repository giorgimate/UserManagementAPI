using System.ComponentModel.DataAnnotations;
using System.Transactions;
using UserManagement.Domain.Transactions;

namespace UserManagement.Domain.Customers
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public float Wallet { get; set; } = 0;
        public Status Status { get; set; } = Status.Active;

        // Navigation property for Transactions
        public List<Transactionn> Transactions { get; set; }
    }
}
