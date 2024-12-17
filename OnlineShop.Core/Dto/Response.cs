namespace OnlineShop.Core.Dto;

public class Response<T>
{
    public Response(T? data, bool success, string message)
    {
        Data = data;
        Success = success;
        Message = message;
    }

    public bool Success { get; }
    public string Message { get; } = string.Empty;
    public T? Data { get; }
}
