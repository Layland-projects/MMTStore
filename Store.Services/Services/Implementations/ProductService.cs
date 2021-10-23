using Store.Application.DTOs;
using Store.Core.Domain;
using Store.Infrastructure.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Implementations
{
    public class ProductService : IProductService
    {
        readonly IProductRepository repo;
        public ProductService(IProductRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<FeaturedProductDTO_Flat>> GetFlatFeaturedProducts()
        {
            return await repo.GetFeaturedProducts<FeaturedProductDTO_Flat>();
        }

        public async Task<IEnumerable<ProductDTO_Flat>> GetProductsByCategoryId(int id)
        {
            return await repo.GetProductsByCategory<ProductDTO_Flat>(id);
        }

        public async Task<IEnumerable<ProductDTO_Flat>> GetProductsByCategoryName(string name)
        {
            return await repo.GetProductsByCategory<ProductDTO_Flat>(name);
        }
    }
}
