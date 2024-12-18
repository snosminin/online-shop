﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            if (await _userManager.Users.AnyAsync(u => u.UserName == request.UserName))
                return BadRequest($"User with such user name already exists");

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
        try
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null) return Unauthorized("Can't find user");

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!result.Succeeded) return Unauthorized("Authentication failed");

            var token = _userService.GetToken(user);
            if (string.IsNullOrEmpty(token)) return Unauthorized("Authentication failed");

            var response = new LoginResponse
            {
                Token = token,
                Username = user.UserName!
            };

            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error in {GetType().Name}: {ex.Message}");
            return BadRequest($"{BadRequest().StatusCode} : {ex.Message}");
        }
    }
}