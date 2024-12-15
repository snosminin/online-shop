namespace OnlineShop.Core.Dto.Auth
{
    public class ErrorResponse:Response
    {
        public ErrorResponse(Error error) : base(false, error)
        {
        }
    }
}
