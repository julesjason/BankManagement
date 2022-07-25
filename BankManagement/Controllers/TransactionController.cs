using BankManagement.Models.Bank;
using BankManagement.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Controllers
{
    public class TransactionController : Controller
    {


        private readonly DataContext _context;
        private readonly ITransactionService _transactionService;
        public TransactionController(DataContext context, ITransactionService transactionService)
        {
            _context = context;
            _transactionService = transactionService;
        }

        // GET: TransactionController
        public ActionResult Index()
        {
           var transactions = _transactionService.TransactionsList(true);
            return View(transactions);
        }

        // GET: TransactionController/Details/5
        public ActionResult Details(int id)
        {
            var transactionDetail = _transactionService.getTransactionId(id);
            return View(transactionDetail);
        }

        // GET: TransactionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransactionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Transaction transaction)
        {
            try
            {
                _transactionService.CreateTransaction(transaction);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionController/Edit/5
        public ActionResult Edit(int id)
        {
            var transaction = _transactionService.getTransactionId(id);
            return View(transaction);
        }

        // POST: TransactionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Transaction transaction)
        {
            try
            {
                transaction.TransactionUpdateDate = DateTime.Now;
                _context.transactions.Update(transaction);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionController/Delete/5
        public ActionResult Delete(int id)
        {
            var transaction = _transactionService.getTransactionId(id);
            return View(transaction);
        }

        // POST: TransactionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Transaction transaction)
        {
            try
            {
                _transactionService.DeleteTransaction(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
