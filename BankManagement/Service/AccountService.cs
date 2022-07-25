using BankManagement.Models.Bank;
using BankManagement.ViewModel.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Service
{
    public class AccountService : IAccountService
    {
        private readonly DataContext _context;

        public AccountService(DataContext context)
        {
            _context = context;
        }
        public Account getAccountId(int id)
        {

            return _context.accounts.Where(a => a.AccountID == id).FirstOrDefault();
        }
        public List<Account> AccountsList()
        {
            return _context.accounts.ToList();
        }
        public List<Account> AccountsList(bool state)
        {
            return _context.accounts.Where(a => a.AccountState == state).ToList();
        }

        public void DeleteAccount(int id)
        {
            var account = getAccountId(id);
            account.AccountDeleteDate = DateTime.Now;
            account.AccountState = false;
            _context.accounts.Update(account);
        }

        public Account UpdateAccount(int id, AccountEditVM a)
        {
            var account = getAccountId(id);
            account.AccountBalance = a.AccountBalance;
            account.CustomerID = a.CustomerID;
            account.AccountUpdateDate = DateTime.Now;
            _context.accounts.Update(account);
            return account;
        }

        public Account CreateAccount(Account account)
        {
            Random rand = new Random();
            account.AccountNumber = rand.Next(1000000, 9999999).ToString();
            foreach (var acc in _context.accounts)
            {
                while(acc.AccountNumber == account.AccountNumber)
                {
                    account.AccountNumber = rand.Next(1000000, 9999999).ToString();
                }
            }
            account.AccountState = true;
            account.AccountCreationDate = DateTime.Now;
            account.AccountUpdateDate = DateTime.Now;

            _context.accounts.Add(account);
            _context.SaveChanges();

            return account;
        }
    }
}
