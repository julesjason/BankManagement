using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Models.Bank
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerFisrtName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { set; get; }
        public string CustomerPhoneNumber { set; get; }
        public DateTime CustomerCreationDate { get; set; }
        public DateTime CustomerUpdateDate { set; get; }
        public DateTime CustomerDeleteDate { get; set; }
        public bool CustomerState { get; set; }
    }
}
