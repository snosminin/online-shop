using MapsterMapper;
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
    private readonly IMapper _mapper;

    public WishlistController(IWishlistService wishlistService,
        UserManager<AppUser> userManager, IMapper mapper)
    {
        _wishlistService = wishlistService;
        _userManager = userManager;
        _mapper = mapper;
    }


    [Authorize(Roles = "Client")]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var user = await _userManager.FindByNameAsync(User.Identity?.Name!);
        var wishlists = await _wishlistService.GetAllWishlistsByUserIdAsync(user?.Id!);
        var mapped = _mapper.Map<List<Wishlist>, List<WishlistDto>>(wishlists);

        return Ok(mapped);
    }
}