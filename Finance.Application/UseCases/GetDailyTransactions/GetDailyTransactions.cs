using Finance.Application.UseCases.Core;
using Finance.Domain.Enums;
using Finance.Domain.Interfaces;
using Finance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.UseCases.GetDailyTransactions
{
    public class GetDailyTransactions : IGetDailyTransactions
    {
        private readonly ITransactionRepository _transactionRepository;
        public GetDailyTransactions(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<Output> Handle(GetDailyTransactionsInput request, CancellationToken cancellationToken)
        {
            IEnumerable<Transaction> transactions = null;

            if(request.Date is null)
                transactions = await _transactionRepository.GetAll();
            else
                transactions = await _transactionRepository.GetByDate(request.Date.Value.ToUniversalTime(), request.Date.Value.AddDays(1).ToUniversalTime());

            var dailyTransactions = transactions
                .GroupBy(x => x.Date.ToString("dd/MM/yyyy"))
                .Select(x => new
                {
                    Date = x.Key,
                    Payable = x.Where(y => y.Type == eType.Payable).Sum(y => y.Value),
                    Receivable = x.Where(y => y.Type == eType.Receivable).Sum(y => y.Value),
                    Amount = x.Where(y => y.Type == eType.Receivable).Sum(y => y.Value) - x.Where(y => y.Type == eType.Payable).Sum(y => y.Value)
                })
                .OrderBy(x => x.Date);

            return new Output(dailyTransactions);
        }
    }
}
