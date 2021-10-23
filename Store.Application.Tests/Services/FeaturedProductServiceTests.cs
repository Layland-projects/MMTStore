using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Store.Application.DTOs;
using Store.Application.DTOs.Create;
using Store.Application.Exceptions;
using Store.Application.Services.Implementations;
using Store.Core.Domain;
using Store.Infrastructure.Persistence.Repositories.Interfaces;

namespace Store.Application.Tests.Services
{
    [TestFixture]
    public class FeaturedProductServiceTests
    {
        [Test]
        public async Task CreateNewFeature_Returns1IfValidModelProvided()
        {
            var repo = new Mock<IFeaturedProductCategoryRepository>(MockBehavior.Strict);
            var catRepo = new Mock<IProductCategoryRepository>(MockBehavior.Strict);
            repo.Setup(x => x.CreateNewFeaturedProductCategory(It.IsAny<FeaturedProductCategory>())).ReturnsAsync(1);
            catRepo.Setup(x => x.GetProductCategory<ProductCategoryDTO_Flat>(1)).ReturnsAsync(new ProductCategoryDTO_Flat { Id = 1 });

            var SUT = new FeaturedProductService(repo.Object, catRepo.Object);

            var res = await SUT.CreateNewFeaturedProduct(new() { CategoryId = 1, ValidFromUtc = DateTime.UtcNow, ValidUntilUtc = null });
            Assert.That(res, Is.EqualTo(1));
        }

        [Test]
        public void CreateNewFeature_ThrowsNotFoundException_IfInvalidCategoryIdProvided()
        {
            var repo = new Mock<IFeaturedProductCategoryRepository>(MockBehavior.Strict);
            var catRepo = new Mock<IProductCategoryRepository>(MockBehavior.Strict);
            catRepo.Setup(x => x.GetProductCategory<ProductCategoryDTO_Flat>(1)).ThrowsAsync(new NotFoundException(typeof(ProductCategory), 1));

            var SUT = new FeaturedProductService(repo.Object, catRepo.Object);

            Assert.ThrowsAsync<NotFoundException>(() => SUT.CreateNewFeaturedProduct(new() { CategoryId = 1, ValidFromUtc = DateTime.UtcNow, ValidUntilUtc = null }));
        }
    }
}
