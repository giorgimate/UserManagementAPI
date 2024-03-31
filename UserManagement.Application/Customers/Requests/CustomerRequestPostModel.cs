using System.ComponentModel.DataAnnotations;

namespace UserManagement.Application.Customers.Requests
{
    public class CustomerRequestPostModel
    {
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
    }
}
