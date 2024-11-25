namespace OnlineShop.Core.Dto.Auth;

public class RegisterUserResponse : Response
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
}