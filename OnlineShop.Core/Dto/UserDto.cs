﻿namespace OnlineShop.Core.Dto;

public class UserDto
{
    public required string Username { get; set; }

    public required string Password { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required string Address { get; set; }

    public required string Email { get; set; }

    public required string PhoneNumber { get; set; }

    public required string Country { get; set; }
}