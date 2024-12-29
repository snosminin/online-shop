using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Dto;
using OnlineShop.Core.Interfaces.Service;
using OnlineShop.Core.Model;

namespace OnlineShop.Server.Controllers;

public class ProductCategoryController : BaseApiController
{
    private readonly IProductCategoryService _productCategoryService;
    private readonly IMapper _mapper;

    public ProductCategoryController(IProductCategoryService productCategoryService, IMapper mapper)
    {
        _productCategoryService = productCategoryService;
        _mapper = mapper;
    }

    [Authorize(Roles = "Client")]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var productCategories = await _productCategoryService.GetAllProductCategoriesAsync();
        var mapped = _mapper.Map<List<ProductCategory>, List<ProductCategoryDto>>(productCategories);

        return Ok(mapped);
    }
}