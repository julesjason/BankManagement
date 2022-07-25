using BankManagement.Models.Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly DataContext _context;

        public Transaction getTransactionId(int id) 
        {
            return _context.transactions.Where(a => a.TransactionID == id).FirstOrDefault();
        }

        public List<Transaction> TransactionsList()
        {
            return _context.transactions.ToList();
        }

        public List<Transaction> TransactionsList(bool state)
        {
            return _context.transactions.Where(a => a.TransactionState == state).ToList();
        }

        public Transaction CreateTransaction(Transaction transaction)
        {
            var account = _context.accounts.Where(a => a.AccountID == transaction.AccountID).FirstOrDefault();
            account.AccountBalance += transaction.TransactionAmount;

            Random random = new Random();
            transaction.TransactionNumber = random.Next(100000, 99999).ToString();
            foreach ( var Trans in _context.transactions)
            {
                while(Trans.TransactionNumber == transaction.TransactionNumber)
                {
                    transaction.TransactionNumber = random.Next(100000, 99999).ToString();
                }
            }
            transaction.TransactionState = true;
            transaction.TransactionCreationDate = DateTime.Now;
            transaction.TransactionUpdateDate = DateTime.Now;
            transaction.TransactionDeleteDate = DateTime.Now;
            _context.transactions.Add(transaction);
            _context.SaveChanges();
            return transaction;
            
        }

        public  void DeleteTransaction(int id)
        {
            var transaction = getTransactionId(id);

            transaction.TransactionState = false;
            transaction.TransactionDeleteDate = DateTime.Now;
            _context.SaveChanges();
        }

    }
}
