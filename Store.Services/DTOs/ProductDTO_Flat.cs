using Store.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.DTOs
{
    public class ProductDTO_Flat : FeaturedProductDTO_Flat
    {
        public string CurrencyCode { get; set; }
        public decimal Price { get; set; }
    }
}
