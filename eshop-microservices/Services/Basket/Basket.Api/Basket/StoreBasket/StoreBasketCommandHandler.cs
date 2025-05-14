namespace Basket.Api.Basket.StoreBasket;

public class StoreBasketCommandHandler(IBasketRepository basketRepository) : IRequestHandler<StoreBasketCommand, string>
{
    public async Task<string> Handle(StoreBasketCommand request, CancellationToken cancellationToken)
    {
        var storedBasket = await basketRepository.StoreBasketAsync(request.ShoppingCart, cancellationToken);
        
        return storedBasket.UserName ?? string.Empty;
    }
}