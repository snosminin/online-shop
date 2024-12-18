namespace OnlineShop.Core.Dto.Auth;

public class RegisterUserResponse : Success<bool>
{
    public RegisterUserResponse() : base(true)
    {
        
    }
}