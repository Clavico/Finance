using Finance.Application.UseCases.Core;
using Finance.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.UseCases.RemoveTransaction
{
    public class RemoveTransaction : IRemoveTransaction
    {
        private readonly ITransactionRepository _transactionRepository;

        public RemoveTransaction(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<Output> Handle(RemoveTransactionInput request, CancellationToken cancellationToken)
        {
            await _transactionRepository.Delete(request.Id);
            return new Output();
        }
    }
}
