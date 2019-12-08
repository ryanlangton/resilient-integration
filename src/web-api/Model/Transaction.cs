using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResilientIntegration.Api.Model
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int TotalCost { get; set; }
        public List<TransactionItem> Items { get; set; }
    }

    public class TransactionItem
    {
        public string Description { get; set; }
        public int Cost { get; set; }
    }
}
