using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Core.Dto.Auth;
using OnlineShop.Core.Model;

namespace OnlineShop.Core.Interfaces.Service;

public interface IUserService
{
    Task<IdentityResult> Create(CreateUserRequest registerUserRequest);
    bool ValidateToken(string token, out JwtSecurityToken? jwt);
    string GetToken(AppUser user);
}