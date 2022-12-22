using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureBoilerplate.Application.Products;
using CleanArchitectureBoilerplate.Contracts.Products;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureBoilerplate.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetById(Guid id)
        {
            // Get service-layer "ProductResult" (to not expose Domain entities)
            var productResult = _productService.GetProductById(id);

            // Map our service-layer "ProductResult" DTO to our presentation "ProductResponse" DTO

            // Return our "ProductResponse"
            return null;
        }
    }
}