namespace OnlineShop.Core.Model;

public class ProductAttachment : BaseEntity
{
    public required string Name { get; set; }

    public byte[] Data { get; set; } = [];

    public required Product Product { get; set; }
}