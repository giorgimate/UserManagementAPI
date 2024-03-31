namespace UserManagement.Application.Exeptions
{
    public class CustomerAlreadyExistException : Exception
    {
        public string Code = "CustomerAlreadyExist";
        public CustomerAlreadyExistException(string message) : base(message)
        {
            
        }
    }
}
