using Store.Application.DTOs;
using Store.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services
{
    public interface IProductService
    {
        Task<IEnumerable<FeaturedProductDTO_Flat>> GetFlatFeaturedProducts();
        Task<IEnumerable<ProductDTO_Flat>> GetProductsByCategoryId(int id);
        Task<IEnumerable<ProductDTO_Flat>> GetProductsByCategoryName(string name);
    }
}
