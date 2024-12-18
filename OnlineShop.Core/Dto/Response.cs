namespace OnlineShop.Core.Dto;

public class Response<T>:BaseResponse<T>
{
    protected Response(T data) : base(data, true,string.Empty)
    {
        
    }
}