using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Dto;
using OnlineShop.Core.Interfaces.Service;

namespace OnlineShop.Server.Controllers;

public class ProductController : BaseApiController
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductService _productService;

    public ProductController(ILogger<ProductController> logger,
        IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    [Authorize(Roles = "Client")]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var products = await _productService.GetAllProductsAsync();
            var mapped = products.Adapt<List<ProductDto>>();

            return Ok(mapped);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error in {GetType().Name}: {ex.Message}");
            return BadRequest($"{BadRequest().StatusCode} : {ex.Message}");
        }
    }
}