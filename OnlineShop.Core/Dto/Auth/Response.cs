namespace OnlineShop.Core.Dto.Auth;

public abstract class Response
{
    protected Response(bool success, Error? error)
    {
        Success = success;
        Error = error;
    }

    public bool Success { get; }
    public Error? Error { get; }
}