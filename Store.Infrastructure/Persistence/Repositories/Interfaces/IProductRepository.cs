using Store.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Persistence.Repositories.Interfaces
{
    public interface IProductRepository
    { 
        Task<IEnumerable<T>> GetProducts<T>() where T : ProductBase;
        Task<IEnumerable<T>> GetFeaturedProducts<T>() where T : ProductBase;
        Task<IEnumerable<T>> GetProductsByCategory<T>(int categoryId) where T : ProductBase;
        Task<IEnumerable<T>> GetProductsByCategory<T>(string categoryName) where T : ProductBase;
        Task<T> GetProduct<T>(int id) where T : ProductBase;
    }
}
