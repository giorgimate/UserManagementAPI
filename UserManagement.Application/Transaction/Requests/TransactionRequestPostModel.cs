using UserManagement.Application.Customers.Requests;

namespace UserManagement.Application.Transaction.Requests
{
    public class TransactionRequestPostModel
    {
        public CustomerLoginModel CustomerLoginModel { get; set; }
        public int ReceiverCustomerId { get; set; }
        public float TransferredAmount { get; set; }
    }
}
