using Finance.Application.UseCases.Core;
using Finance.Domain.Interfaces;
using Finance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.UseCases.UpdateTransaction
{
    public class UpdateTransaction : IUpdateTransaction
    {
        private readonly ITransactionRepository _transactionRepository;

        public UpdateTransaction(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<Output> Handle(UpdateTransactionInput request, CancellationToken cancellationToken)
        {
            await _transactionRepository.Edit(new Transaction(request.Id, request.Description, request.Value, request.Type, request.Date));
            return new Output();
        }
    }
}
