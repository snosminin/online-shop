namespace OnlineShop.Core.Dto
{
    public class Error : Response<object>
    {
        public Error(string message) : base(null,false, message)
        {
        }
    }
}
