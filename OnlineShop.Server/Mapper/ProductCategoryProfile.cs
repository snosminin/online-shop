using Mapster;
using OnlineShop.Core.Dto;
using OnlineShop.Core.Model;

namespace OnlineShop.Server.Mapper;

public class ProductCategoryProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ProductCategory, ProductCategoryDto>()
            .RequireDestinationMemberSource(true);
    }
}