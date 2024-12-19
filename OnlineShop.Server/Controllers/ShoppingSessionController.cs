using Mapster;
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

    public ShoppingSessionController(IShoppingSessionService shoppingSessionService, UserManager<AppUser> userManager)
    {
        _shoppingSessionService = shoppingSessionService;
        _userManager = userManager;
    }

    [Authorize(Roles = "Client")]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var user = await _userManager.FindByNameAsync(User.Identity?.Name!);
        var shoppingSession = await _shoppingSessionService.GetShoppingSessionByUserIdAsync(user?.Id!);
        var mapped = shoppingSession.Adapt<ShoppingSessionDto>();

        return Ok(mapped);
    }
}