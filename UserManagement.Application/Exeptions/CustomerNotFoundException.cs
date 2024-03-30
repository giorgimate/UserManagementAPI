using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
