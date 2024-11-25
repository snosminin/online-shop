using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Core.Data;
using OnlineShop.Core.Dto.Auth;
using OnlineShop.Core.Interfaces.Service;
using OnlineShop.Core.Model;
using LoginRequest = OnlineShop.Core.Dto.Auth.LoginRequest;

namespace OnlineShop.Core.Services;

public class UserService : IUserService
{
    private readonly IConfiguration _configuration;
    private readonly OnlineShopDbContext _dbContext;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;


    public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
        IConfiguration configuration, OnlineShopDbContext dbContext)
    {
        _userManager = userManager;
        _dbContext = dbContext;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    public async Task<IdentityResult> Create(RegisterUserRequest registerUserRequest)
    {
        var appUser = new AppUser { Email = registerUserRequest.Email, UserName = registerUserRequest.UserName };
        var identityResult = await _userManager.CreateAsync(appUser, registerUserRequest.Password);
        if (identityResult.Succeeded) identityResult = await _userManager.AddToRoleAsync(appUser, "Client");
        return identityResult;
    }

    public async Task<LoginResponse> Login(LoginRequest loginRequest)
    {
        var result =
            await _signInManager.PasswordSignInAsync(loginRequest.Username, loginRequest.Password, false, false);
        if (!result.Succeeded) throw new Exception("Invalid credentials");

        var user = await _userManager.FindByNameAsync(loginRequest.Username);
        if (user == null || string.IsNullOrEmpty(user.UserName)) throw new Exception("No such user");

        var token = GetToken(user);

        return new LoginResponse
        {
            Token = token,
            Username = user.UserName
        };
    }

    public bool ValidateToken(string token, out JwtSecurityToken? jwt)
    {
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = false,
            ValidateLifetime = true
        };

        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
            jwt = (JwtSecurityToken)validatedToken;

            return true;
        }
        catch (SecurityTokenValidationException)
        {
            jwt = null;
            return false;
        }
    }

    private string GetToken(AppUser user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]!);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new(ClaimTypes.Name, user.UserName!),
                new(ClaimTypes.Role, "Client")
            }),
            Expires = DateTime.MaxValue,
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var userToken = tokenHandler.WriteToken(token);
        if (string.IsNullOrEmpty(userToken)) throw new Exception("Authorization failed");

        return userToken;
    }
}