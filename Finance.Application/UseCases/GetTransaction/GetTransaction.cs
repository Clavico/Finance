using Finance.Application.UseCases.Core;
using Finance.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.UseCases.GetTransaction
{
    public class GetTransaction : IGetTransaction
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetTransaction(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<Output> Handle(GetTransactionInput request, CancellationToken cancellationToken)
        {
            var result = await _transactionRepository.Get(request.Id);
            return new Output(result);
        }
    }
}
