namespace OnlineShop.Core.Dto;

public class Success<T>:Response<T>
{
    protected Success(T data) : base(data, true,string.Empty)
    {
        
    }
}