using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Dto;
using OnlineShop.Core.Interfaces.Service;
using OnlineShop.Core.Model;

namespace OnlineShop.Server.Controllers;

public class ShoppingSessionController : BaseApiController
{
    private readonly IShoppingSessionService _shoppingSessionService;
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;

    public ShoppingSessionController(IShoppingSessionService shoppingSessionService, UserManager<AppUser> userManager, IMapper mapper)
    {
        _shoppingSessionService = shoppingSessionService;
        _userManager = userManager;
        _mapper = mapper;
    }

    [Authorize(Roles = "Client")]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var user = await _userManager.FindByNameAsync(User.Identity?.Name!);
        var shoppingSession = await _shoppingSessionService.GetShoppingSessionByUserIdAsync(user?.Id!);
        var mapped = _mapper.Map<ShoppingSession, ShoppingSessionDto>(shoppingSession);

        return Ok(mapped);
    }
}