using UserManagement.Application.Transaction.Responses;

namespace UserManagement.Application.Customers.Respones
{
    public class CustomerResponseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public float Wallet { get; set; }
        public List<TransactionResponseModel> SentTransactions { get; set; }
        public List<TransactionResponseModel> ReceivedTransactions { get; set; }
    }
}
