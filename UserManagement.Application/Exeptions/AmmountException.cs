namespace UserManagement.Application.Exeptions
{
    public class AmmountException : Exception
    {
        public string Code = "Insufficient Balance";
        public AmmountException(string message) : base(message)
        {
            
        }
    }
}
