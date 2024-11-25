namespace OnlineShop.Core.Dto.Auth;

public abstract class Response
{
    protected Response(bool success = false, string errorMessage = "")
    {
        Success = success;
        ErrorMessage = errorMessage;
    }

    public bool Success { get; }
    public string ErrorMessage { get; }
}