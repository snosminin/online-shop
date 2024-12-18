using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Dto;
using OnlineShop.Core.Interfaces.Service;

namespace OnlineShop.Server.Controllers;

public class ProductCategoryController : BaseApiController
{
    private readonly IProductCategoryService _productCategoryService;

    public ProductCategoryController(IProductCategoryService productCategoryService)
    {
        _productCategoryService = productCategoryService;
    }

    [Authorize(Roles = "Client")]
    [HttpGet]
    public async Task<IActionResult> Get()
    {

        var productCategories = await _productCategoryService.GetAllProductCategoriesAsync();
        var mapped = productCategories.Adapt<List<ProductCategoryDto>>();

        return Ok(mapped);
    }
}