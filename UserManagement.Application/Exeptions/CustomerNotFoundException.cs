namespace UserManagement.Application.Exeptions
{
    public class CustomerNotFoundException : Exception
    {
        public string Code = "CustomerNotFound";
        public CustomerNotFoundException(string message) : base(message)
        {
            
        }
    }
}
