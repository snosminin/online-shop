using Mapster;
using OnlineShop.Core.Dto;
using OnlineShop.Core.Model;

namespace OnlineShop.Server.Mapper;

public class ProductCategoryProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ProductCategory, ProductCategoryDto>()
            .RequireDestinationMemberSource(true).TwoWays();

        config.NewConfig<Product, ProductDto>()
            .RequireDestinationMemberSource(true).TwoWays();

        config.NewConfig<Discount, DiscountDto>()
            .RequireDestinationMemberSource(true).TwoWays();

        config.NewConfig<CartItem, CartItemDto>()
            .RequireDestinationMemberSource(true).TwoWays();

        config.NewConfig<ShoppingSession, ShoppingSessionDto>()
            .RequireDestinationMemberSource(true).TwoWays();

        config.NewConfig<Wishlist, WishlistDto>()
            .RequireDestinationMemberSource(true).TwoWays();
    }
}