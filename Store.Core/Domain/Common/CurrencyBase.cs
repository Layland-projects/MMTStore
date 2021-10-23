using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Domain.Common
{
    public abstract class CurrencyBase
    {
        public string Code { get; protected set; }
    }
}
