using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserManagement.Domain.BaseEntities;
using UserManagement.Domain.Customers;

namespace UserManagement.Domain.Transactions
{
    public class Transactionn:BaseEntity
    {
        [ForeignKey("SenderCustomer")]
        public int SenderCustomerId { get; set; }
        [ForeignKey("ReceiverCustomer")]
        public int ReceiverCustomerId { get; set; }
        public float TransferredAmount { get; set; }
        public DateTime DateOfTransfer { get; set; }
        public Customer SenderCustomer { get; set; }
        public Customer ReceiverCustomer { get; set; }
    }
}
