using Finance.Application.UseCases.Core;
using Finance.Domain.Interfaces;
using Finance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.UseCases.CreateTransaction
{
    public class CreateTransaction : ICreateTransaction
    {
        private readonly ITransactionRepository _transactionRepository;

        public CreateTransaction(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<Output> Handle(CreateTransactionInput request, CancellationToken cancellationToken)
        {
            await _transactionRepository.Add(new Transaction(request.Description, request.Value, request.Type, request.Date));
            return new Output();
        }
    }
}
