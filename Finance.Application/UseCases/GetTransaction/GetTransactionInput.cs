using Finance.Application.UseCases.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.UseCases.GetTransaction
{
    public class GetTransactionInput : IRequest<Output>
    {
        public GetTransactionInput(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
