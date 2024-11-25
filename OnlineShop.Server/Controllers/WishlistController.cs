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
    private readonly ILogger<WishlistController> _logger;
    private readonly UserManager<AppUser> _userManager;
    private readonly IWishlistService _wishlistService;

    public WishlistController(ILogger<WishlistController> logger,
        IWishlistService wishlistService,
        UserManager<AppUser> userManager)
    {
        _logger = logger;
        _wishlistService = wishlistService;
        _userManager = userManager;
    }


    [Authorize(Roles = "Client")]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var user = await _userManager.FindByNameAsync(User.Identity?.Name!);
            var wishlists = await _wishlistService.GetAllWishlistsByUserIdAsync(user?.Id!);
            var mapped = wishlists.Adapt<List<WishlistDto>>();

            return Ok(mapped);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error in {GetType().Name}: {ex.Message}");
            return BadRequest($"{BadRequest().StatusCode} : {ex.Message}");
        }
    }
}