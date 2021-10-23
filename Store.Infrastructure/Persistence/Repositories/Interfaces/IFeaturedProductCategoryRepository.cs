using Store.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Persistence.Repositories.Interfaces
{
    public interface IFeaturedProductCategoryRepository
    {
        Task<int> CreateNewFeaturedProductCategory<T>(T newObj) where T : FeaturedProductCategory;
    }
}
