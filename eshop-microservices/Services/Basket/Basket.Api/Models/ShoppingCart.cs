namespace Basket.Api.Models;

public class ShoppingCart
{
    public string? UserName { get; set; }
    public List<ShoppingCartItem>? Items { get; set; } = [];
    public decimal TotalPrice => Items?.Sum(item => item.Price * item.Quantity) ?? 0;

    public ShoppingCart(string userName)
    {
        UserName = userName;
    }

    public ShoppingCart()
    {
    }
}