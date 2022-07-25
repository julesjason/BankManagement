using BankManagement.Models.Bank;
using BankManagement.ViewModel.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Service 
{
    public class CustomerService : ICustomerService
    {
        private readonly DataContext _context;

        public CustomerService(DataContext Context)
        {
            _context = Context;
        }

        public Customer getId(int id)
        {
            return _context.customers.Where(a => a.CustomerID == id).FirstOrDefault();
        }

        public List<Customer> CustomersList()
        {
            return _context.customers.ToList();
        }

        public List<Customer> CustomersList(bool state)
        {
            return _context.customers.Where(a => a.CustomerState == state).ToList();
        }

        public Customer CreateCustomer(Customer customer)
        {

            customer.CustomerState = true;
            customer.CustomerCreationDate = DateTime.Now;
            customer.CustomerUpdateDate = DateTime.Now;
            customer.CustomerUpdateDate = DateTime.Now;
            _context.customers.Add(customer);
            _context.SaveChanges();

            return customer;

        }

        public Customer updateCustomer(int id, CustomerEditVM c)
        {
            var customer = getId(id);
            customer.CustomerFisrtName = c.CustomerFirstName;
            customer.CustomerLastName = c.CustomerLastName;
            customer.CustomerEmail = c.CustomerEmail;
            customer.CustomerPhoneNumber = c.CustomerPhoneNumber;
            customer.CustomerUpdateDate = DateTime.Now;
            _context.customers.Update(customer);
            _context.SaveChanges();

            return customer;
        }

        public void DeleteCustomer(int id)
        {
            var customer = getId(id);
            customer.CustomerDeleteDate = DateTime.Now;
            customer.CustomerState = false;
            _context.Update(customer);
            _context.SaveChanges();
        }
    }
}
