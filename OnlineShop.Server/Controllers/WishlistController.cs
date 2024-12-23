using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Dto;
using OnlineShop.Core.Interfaces.Service;
using OnlineShop.Core.Model;

namespace OnlineShop.Server.Controllers;

public class WishlistController : BaseApiController
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IWishlistService _wishlistService;

    public WishlistController(IWishlistService wishlistService,
        UserManager<AppUser> userManager)
    {
        _wishlistService = wishlistService;
        _userManager = userManager;
    }


    [Authorize(Roles = "Client")]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var user = await _userManager.FindByNameAsync(User.Identity?.Name!);
        var wishlists = await _wishlistService.GetAllWishlistsByUserIdAsync(user?.Id!);
        var mapped = wishlists.Adapt<List<WishlistDto>>();

        return Ok(mapped);
    }
}