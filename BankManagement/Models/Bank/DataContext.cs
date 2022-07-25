using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace BankManagement.Models.Bank
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration _Configuration;
        public DataContext( IConfiguration configuration)
        {
            _Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseMySql(_Configuration.GetConnectionString("dataAccess"));
        }
        public DbSet<Account> accounts { get; set; }
        public DbSet<Customer> customers { set; get; }
        public DbSet<Transaction> transactions { set; get; }

    }
}
