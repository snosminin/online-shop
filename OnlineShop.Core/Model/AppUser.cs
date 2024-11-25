using Microsoft.AspNetCore.Identity;

namespace OnlineShop.Core.Model;

public class AppUser : IdentityUser
{
    public ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
    public ICollection<ShoppingSession> ShoppingSessions { get; set; } = new List<ShoppingSession>();
}