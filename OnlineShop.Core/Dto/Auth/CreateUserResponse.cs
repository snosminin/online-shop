namespace OnlineShop.Core.Dto.Auth;

public class CreateUserResponse(bool creationSucceed)
{
    public bool CreationSucceed { get; } = creationSucceed;
}