using Store.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Domain
{
    public class Currency : CurrencyBase
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
