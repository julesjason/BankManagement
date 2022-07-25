using BankManagement.Models.Bank;
using BankManagement.Service;
using BankManagement.ViewModel.Customers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Controllers
{
    public class CustomerController : Controller
    {
        //add our data contex and interface service
        private readonly DataContext _context;

        private readonly ICustomerService _customerService;

        //Create our constructor
        public CustomerController(DataContext dataContext, ICustomerService customerService)
        {
            _context = dataContext;
            _customerService = customerService;
        }

        // GET: CustomerController
        public ActionResult Index()
        {
            var customer = _customerService.CustomersList(true);
            return View(customer);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            var customer = _customerService.getId(id);
            return View(customer);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                _customerService.CreateCustomer(customer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            var cutomer = _customerService.getId(id);
            return View(cutomer);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerEditVM customer)
        {
            try
            {
                _customerService.updateCustomer(id, customer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = _customerService.getId(id);
            return View(customer);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,Customer customer)
        {
            try
            {
                _customerService.DeleteCustomer(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
