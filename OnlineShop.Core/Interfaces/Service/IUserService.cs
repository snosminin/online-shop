using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Core.Dto.Auth;

namespace OnlineShop.Core.Interfaces.Service;

public interface IUserService
{
    Task<IdentityResult> Create(RegisterUserRequest registerUserRequest);
    Task<LoginResponse> Login(LoginRequest loginRequest);
    bool ValidateToken(string token, out JwtSecurityToken? jwt);
}