using BankManagement.Models.Bank;
using BankManagement.Service;
using BankManagement.ViewModel.Accounts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataContext _context;

        private readonly IAccountService _accountService;


        //The class constructor
        public AccountController(DataContext dataContext, IAccountService accountService)
        {
            _context = dataContext;
            _accountService = accountService;
        }


        // GET: AccountController
        public ActionResult Index()
        {
            var account = _accountService.AccountsList(true);

            return View(account);
        }

        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            var account = _accountService.getAccountId(id);
            return View(account);
        }

        // GET: AccountController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Account account)
        {
            try
            {
                _accountService.CreateAccount(account);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            var account = _accountService.getAccountId(id);
            return View(account);
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AccountEditVM account)
        {
            try
            {
                _accountService.UpdateAccount(id, account);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            var account =_accountService.getAccountId(id);
            return View(account);
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Account account)
        {
            try
            {
                _accountService.DeleteAccount(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
