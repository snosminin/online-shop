using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Core.Dto.Auth;
using OnlineShop.Core.Interfaces.Service;
using OnlineShop.Core.Model;

namespace OnlineShop.Server.Controllers;

[Produces("application/json")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly ILogger<AccountController> _logger;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;
    private readonly IUserService _userService;

    public AccountController(ILogger<AccountController> logger, IUserService userService,
        SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
    {
        _userService = userService;
        _logger = logger;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [Route("api/register")]
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
    {
        try
        {
            var result = await _userService.Create(request);
            return result.Succeeded ? Ok(result.Succeeded) : BadRequest(result.Errors);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error in {GetType().Name}: {ex.Message}");
            return BadRequest($"{BadRequest().StatusCode} : {ex.Message}");
        }
    }

    [Route("api/login")]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _userManager.FindByNameAsync(request.Username);
        if (user == null) return Unauthorized("Can't find user");

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
        if (!result.Succeeded) return Unauthorized("Authentication failed");

        var token = _userService.GetToken(user);
        var response = new LoginResponse
        {
            Token = token,
            Username = user.UserName!
        };

        return Ok(response);
    }
}