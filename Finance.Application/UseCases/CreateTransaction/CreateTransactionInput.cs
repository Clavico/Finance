using Finance.Application.UseCases.Core;
using Finance.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.UseCases.CreateTransaction
{
    public class CreateTransactionInput : IRequest<Output>
    {
        public string Description { get; set; }
        public decimal Value { get; set; }
        public eType Type { get; set; }
        public DateTime Date { get; set; }

    }
}
