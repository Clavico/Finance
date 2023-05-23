using Finance.Application.UseCases.Core;
using Finance.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.UseCases.GetAllTransactions
{
    public class GetAllTransactions : IGetAllTransactions
    {
        private readonly ITransactionRepository _transactionRepository;
        public GetAllTransactions(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<Output> Handle(GetAllTransactionsInput request, CancellationToken cancellationToken)
        {
            var result = await _transactionRepository.GetAll();
            return new Output(result);
        }
    }
}
