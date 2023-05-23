using Finance.Domain.Interfaces;
using Finance.Domain.Models;
using Finance.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infra.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly FinanceContext _context;

        public TransactionRepository(FinanceContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Transaction>> GetAll()
        {
            return _context.Transactions.ToList();
        }

        public async Task<IEnumerable<Transaction>> GetByDate(DateTime startDate, DateTime endDate)
        {
            return _context
                .Transactions
                .Where(x => x.Date >= startDate && x.Date <= endDate)
                .ToList();
        }

        public async Task<Transaction> Get(int id)
        {
            return _context.Transactions.FirstOrDefault(x => x.Id == id);
        }

        public async Task Add(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }

        public async Task Edit(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
            _context.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var transaction = _context.Transactions.FirstOrDefault(x => x.Id == id);
            _context.Transactions.Remove(transaction);
            _context.SaveChanges();
        }
    }
}
