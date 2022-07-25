using BankManagement.Models.Bank;
using BankManagement.ViewModel.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Service
{
    public interface ICustomerService
    {
        public List<Customer> CustomersList();

        public List<Customer> CustomersList(bool state);

        public Customer CreateCustomer(Customer customer);
        public Customer getId(int id);

        public void DeleteCustomer(int id);
        public Customer updateCustomer(int id, CustomerEditVM c);
    }
}
