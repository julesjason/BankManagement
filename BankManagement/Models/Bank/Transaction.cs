using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Models.Bank
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public string TransactionNumber { get; set; }
        public double TransactionAmount { get; set; }
        public DateTime TransactionCreationDate { get; set; }
        public DateTime TransactionUpdateDate { set; get; }
        public DateTime TransactionDeleteDate { get; set; }
        public bool TransactionState { get; set; }
        public int AccountID { get; set; }
        public Account AccountTransaction { get; set; }
    }
}
