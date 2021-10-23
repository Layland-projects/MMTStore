using Store.Application.DTOs;
using Store.Application.DTOs.Create;
using Store.Application.Exceptions;
using Store.Core.Domain;
using Store.Infrastructure.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Implementations
{
    public class FeaturedProductService : IFeaturedProductService
    {
        readonly IFeaturedProductCategoryRepository featuredRepo;
        readonly IProductCategoryRepository catRepo;
        public FeaturedProductService(IFeaturedProductCategoryRepository featuredRepo, IProductCategoryRepository catRepo)
        {
            this.featuredRepo = featuredRepo;
            this.catRepo = catRepo;
        }

        public async Task<int> CreateNewFeaturedProduct(FeaturedProductDTO_Create obj)
        {
            var cat = await catRepo.GetProductCategory<ProductCategoryDTO_Flat>(obj.CategoryId);
            if (cat == null)
                throw new NotFoundException(typeof(ProductCategory), obj.CategoryId);
            var newFeature = new FeaturedProductCategory
            {
                CategoryId = obj.CategoryId,
                ValidFrom = obj.ValidFromUtc,
                ValidUntil = obj.ValidUntilUtc
            };
            return await featuredRepo.CreateNewFeaturedProductCategory(newFeature);
        }
    }
}
