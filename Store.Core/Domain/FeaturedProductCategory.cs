using Store.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Domain
{
    public class FeaturedProductCategory : IAuditableEntity
    {
        public int Id { get; set; }
        public ProductCategory Category { get; set; }
        public int CategoryId { get; set; }
        public DateTimeOffset ValidFrom { get; set; }
        public DateTimeOffset? ValidUntil { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
