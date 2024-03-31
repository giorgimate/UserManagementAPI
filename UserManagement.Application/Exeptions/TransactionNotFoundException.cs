namespace UserManagement.Application.Exeptions
{
    public class TransactionNotFoundException : Exception
    {
        public string Code = "TransactionNotFound";
        public TransactionNotFoundException(string message) : base(message)
        {

        }
    }
}
