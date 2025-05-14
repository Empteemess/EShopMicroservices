namespace Basket.Api.Basket.StoreBasket;

public record StoreBasketCommand(ShoppingCart ShoppingCart) : IRequest<string>;
