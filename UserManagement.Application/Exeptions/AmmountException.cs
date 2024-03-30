using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
