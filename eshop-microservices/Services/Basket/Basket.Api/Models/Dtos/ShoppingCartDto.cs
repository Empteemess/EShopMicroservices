namespace Basket.Api.Models.Dtos;

public class ShoppingCartDto
{
    public string? UserName { get; set; }
    public List<ShoppingCartItemDto>? Items { get; set; } = [];
}