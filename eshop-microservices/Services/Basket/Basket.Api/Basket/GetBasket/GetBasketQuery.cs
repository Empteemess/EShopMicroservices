namespace Basket.Api.Basket.GetBasket;

public record GetBasketQuery(string UserName) : IRequest<ShoppingCart>;
