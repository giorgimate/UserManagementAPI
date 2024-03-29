using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Application.Transaction.Responses
{
    public class TransactionResponseModel
    {
        public int Id { get; set; }
        public int SenderCustomerId { get; set; }
        public int ReceiverCustomerId { get; set; }
        public float TransferredAmount { get; set; }
        public DateTime DateOfTransfer { get; set; }
    }
}
