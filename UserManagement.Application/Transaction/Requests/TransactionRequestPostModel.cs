using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Customers;

namespace UserManagement.Application.Transaction.Requests
{
    public class TransactionRequestPostModel
    {
        public int SenderCustomerId { get; set; }
        public int ReceiverCustomerId { get; set; }
        public float TransferredAmount { get; set; }
        public DateTime DateOfTransfer { get; set; }
    }
}
