using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Models.Bank
{
    public class Account
    {
        public int AccountID { get; set; }
        public string AccountNumber { get; set; }
        public double AccountBalance { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public DateTime AccountUpdateDate { set; get; }
        public DateTime AccountDeleteDate { get; set; }
        public bool AccountState { get; set; }
        public int CustomerID { get; set; }
        public Customer CustomerAccount { get; set; }
    }
}
