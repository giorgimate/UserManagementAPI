using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
