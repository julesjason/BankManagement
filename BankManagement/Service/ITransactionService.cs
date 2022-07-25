using BankManagement.Models.Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Service
{
    public interface ITransactionService
    {
        public List<Transaction> TransactionsList();

        public List<Transaction> TransactionsList(bool state);

        public Transaction CreateTransaction(Transaction transaction);
        public Transaction getTransactionId(int id);

        public void DeleteTransaction(int id);
    }
}
