using Finance.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infra.Context
{
    public class FinanceContext : DbContext
    {

        public FinanceContext(DbContextOptions options) 
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            new TransactionMap(builder.Entity<Transaction>());
        }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
