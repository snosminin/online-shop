namespace OnlineShop.Core.Model;

public class OrderDetail : BaseEntity
{
    public required AppUser User { get; set; }

    public int Total { get; set; }
}