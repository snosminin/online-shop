namespace OnlineShop.Core.Dto
{
    public class Error : BaseResponse<object>
    {
        public Error(string errorMessage) : base(null,false, errorMessage)
        {
        }
    }
}
