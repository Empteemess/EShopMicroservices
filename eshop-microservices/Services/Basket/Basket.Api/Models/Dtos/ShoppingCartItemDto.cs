namespace Basket.Api.Models.Dtos;

public class ShoppingCartItemDto
{
    public int Quantity { get; set; }
    public string? Color { get; set; }
    public decimal Price { get; set; }
    public string? ProductName { get; set; }
}