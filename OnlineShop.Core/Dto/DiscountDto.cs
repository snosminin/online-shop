namespace OnlineShop.Core.Dto;

public class DiscountDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public double Value { get; set; }
}