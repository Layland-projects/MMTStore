using Microsoft.AspNetCore.Mvc;
using Store.Application.DTOs.Create;
using Store.Application.Exceptions;
using Store.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeaturedProductCategoryController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateNew([FromServices] IFeaturedProductService featuredServ, [FromBody] FeaturedProductDTO_Create createModel)
        {
            try
            {
                var res = await featuredServ.CreateNewFeaturedProduct(createModel);
                return Ok(); //By convention I'd normally return a 201 created here but didn't want to spend extra time setting up the services etc to support that.
            }
            catch (NotFoundException)
            {
                return BadRequest($"No category found for : {createModel.CategoryId}");
            }
        }
    }
}
