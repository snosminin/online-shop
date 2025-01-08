using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Dto;
using OnlineShop.Core.Interfaces.Service;
using OnlineShop.Core.Model;

namespace OnlineShop.Server.Controllers;

[Produces("application/json")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IProductCategoryService _productCategoryService;
    private readonly IMapper _mapper;

    public ProductController(IProductService productService, IMapper mapper,
        IProductCategoryService productCategoryService)
    {
        _productService = productService;
        _mapper = mapper;
        _productCategoryService = productCategoryService;
    }

    [Authorize(Roles = "Client")]
    [HttpGet]
    [Route("api/[controller]/")]
    public async Task<IActionResult> Get(string? productCategoryName)
    {
        List<Product> products;
        if (string.IsNullOrEmpty(productCategoryName))
            products = await _productService.GetAllAsync();
        else
        {
            var productCategory = await _productCategoryService.GetByNameAsync(productCategoryName);
            if (productCategory == null)
                return NotFound("Can't find category with such name");
            products = await _productService.GetByProductCategoryIdAsync(productCategory.Id);
        }

        var mapped = _mapper.Map<List<Product>, List<ProductDto>>(products);
        return Ok(mapped);
    }
}