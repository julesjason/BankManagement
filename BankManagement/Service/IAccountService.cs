using BankManagement.Models.Bank;
using BankManagement.ViewModel.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Service
{
    public interface IAccountService
    {
        public List<Account> AccountsList();
        public List<Account> AccountsList(bool state);
        public Account getAccountId(int id);
        public void DeleteAccount(int id);
        public Account UpdateAccount(int id, AccountEditVM a);
        public Account CreateAccount(Account account);

    }
}
