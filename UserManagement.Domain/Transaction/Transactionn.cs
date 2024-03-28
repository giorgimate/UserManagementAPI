using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserManagement.Domain.Customers;

namespace UserManagement.Domain.Transactions
{
    public class Transactionn
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("SenderCustomer")]
        public int SenderCustomerId { get; set; }
        [ForeignKey("ReceiverCustomer")]
        public int ReceiverCustomerId { get; set; }
        public float TransferredAmount { get; set; }
        public Status Status { get; set; } = Status.Active;
        public DateTime DateOfTransfer { get; set; }
        public Customer SenderCustomer { get; set; }
        public Customer ReceiverCustomer { get; set; }
    }
}
