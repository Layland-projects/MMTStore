using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Persistence.Repositories.Interfaces
{
    public interface IProductCategoryRepository
    {
        Task<IEnumerable<T>> GetProductCategories<T>();
        Task<T> GetProductCategory<T>(int id);
        Task<T> GetProductCategory<T>(string name);
    }
}
