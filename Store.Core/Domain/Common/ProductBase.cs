using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Domain
{
    public abstract class ProductBase
    {
        public string SKU { get; protected set; }
    }
}
