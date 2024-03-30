using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Customers.Interfaces;
using UserManagement.Application.Transaction.Interfaces;

namespace UserManagement.Application
{
    public interface IUnitOfWork
    {
         ICustomerRepository Customers { get; }
         ITransactionRepository Transactions { get; }
    }
}
