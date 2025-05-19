using Basket.Api.Models.Dtos;

namespace Basket.Api.Basket.StoreBasket;

public record StoreBasketCommand : IRequest<string>
{
    public string? UserName { get; set; }
    public List<ShoppingCartItemDto>? Items { get; set; } = [];
};