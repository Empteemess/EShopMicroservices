namespace Basket.Api.Basket.DeleteBasket;

public record DeleteBasketCommand(string UserName) : IRequest<bool>;
