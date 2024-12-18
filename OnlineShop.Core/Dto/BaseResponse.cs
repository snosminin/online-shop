namespace OnlineShop.Core.Dto;

public abstract class BaseResponse<T>
{
    protected BaseResponse(T? data, bool success, string errorMessage)
    {
        Data = data;
        Success = success;
        ErrorMessage = errorMessage;
    }

    public bool Success { get; }
    public string ErrorMessage { get; } = string.Empty;
    public T? Data { get; }
}
