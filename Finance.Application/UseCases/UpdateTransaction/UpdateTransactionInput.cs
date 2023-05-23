using Finance.Application.UseCases.Core;
using Finance.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.UseCases.UpdateTransaction
{
    public class UpdateTransactionInput : IRequest<Output>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public eType Type { get; set; }
        public DateTime Date { get; set; }
    }
}
