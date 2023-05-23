using Finance.Application.UseCases.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.UseCases.RemoveTransaction
{
    public class RemoveTransactionInput : IRequest<Output>
    {
        public RemoveTransactionInput(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
