namespace OnlineShop.Core.Model;

public class PaymentDetail : BaseEntity
{
    public required string Status { get; set; }

    public string? Provider { get; set; }

    public double Amount { get; set; }

    public required OrderDetail OrderDetail { get; set; }
}