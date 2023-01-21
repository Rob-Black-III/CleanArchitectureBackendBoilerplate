using CleanArchitectureBoilerplate.Application.Common.Services;
using CleanArchitectureBoilerplate.Application.Common.Status;
using CleanArchitectureBoilerplate.Application.Products;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using static CleanArchitectureBoilerplate.API.Authentication.AuthenticationPresentationDTOs;

namespace CleanArchitectureBoilerplate.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICleanArchitectureBoilerplateStatusService _statusService;
        private readonly ICleanArchitectureBoilerplateLogger _logger;
        //private readonly IMapper _mapper;

        public ProductsController(IProductService productService, ICleanArchitectureBoilerplateStatusService statusService, ICleanArchitectureBoilerplateLogger logger)
        {
            _productService = productService;
            _statusService = statusService;
            _logger = logger;
            //_mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            // Get service-layer "ProductResult" (to not expose Domain entities)
            var productResult = _productService.GetProductById(id);

            // Map our service-layer "ProductResult" DTO to our presentation "ProductResponse" DTO

            // Return our "ProductResponse"
            return null;
        }

        [HttpPost("add")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductAdd productAdd, IValidator<ProductAdd> validator)
        {
            ValidationResult validationResult = await validator.ValidateAsync(productAdd);

            if (!validationResult.IsValid)
            {
                // Log the validation errors
                _logger.LogInfo(String.Join(" ", validationResult.Errors));

                // Send validation errors back to the frontend for toast and such.
                List<string> validationErrors = new List<string>();
                validationResult.Errors.ForEach(f => validationErrors.Add(f.ErrorMessage));
                _statusService.AddStatus(StatusType.VALIDATION_ISSUE, validationErrors, StatusSeverity.ERROR);

                return BadRequest(new JObject());
            }

            ProductResult p = await _productService.CreateProduct(productAdd);

            return Ok(p);
        }
    }
}