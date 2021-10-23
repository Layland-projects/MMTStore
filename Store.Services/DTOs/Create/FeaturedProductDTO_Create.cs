using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.DTOs.Create
{
    public class FeaturedProductDTO_Create
    {
        public int CategoryId { get; set; }
        public DateTime ValidFromUtc { get; set; }
        public DateTime? ValidUntilUtc { get; set; }
    }
}
