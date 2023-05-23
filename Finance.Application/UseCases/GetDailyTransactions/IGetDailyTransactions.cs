using Finance.Application.UseCases.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.UseCases.GetDailyTransactions
{
    public interface IGetDailyTransactions : IRequestHandler<GetDailyTransactionsInput, Output>
    {
    }
}
