using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Dto;
using OnlineShop.Core.Interfaces.Service;
using OnlineShop.Core.Model;

namespace OnlineShop.Server.Controllers;

public class ProductController : BaseApiController
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    [Authorize(Roles = "Client")]
    [HttpGet]
    public async Task<IActionResult> Get(string productCategoryName)
    {
        var products = await _productService.GetAllProductsByProductCategoryAsync(productCategoryName);
        var mapped = _mapper.Map<List<Product>, List<ProductDto>>(products);

        return Ok(mapped);
    }
}