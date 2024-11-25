﻿namespace OnlineShop.Core.Dto.Auth;

public class AuthResult
{
    public required string Token { get; set; }
    public required string RefreshToken { get; set; }
    public bool Success { get; set; }
    public List<string>? Errors { get; set; }
}