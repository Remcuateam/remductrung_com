using Microsoft.AspNetCore.Mvc;
using AspNetMvc.Services.ECommerce.ProductCategories;

namespace AspNetMvc.API.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_productCategoryService.GetAll());
        }
    }
}