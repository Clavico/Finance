using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.UseCases.Core
{
    public class Output
    {
        public Output(bool isValid = true)
        {
            IsValid = isValid;
        }

        public Output(object result)
        {
            IsValid = true;
            Result = result;
        }

        public bool IsValid { get; set; }
        public object Result { get; set; }
    }
}
