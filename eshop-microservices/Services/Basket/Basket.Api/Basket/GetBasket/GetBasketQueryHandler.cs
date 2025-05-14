using Basket.Api.Data;

namespace Basket.Api.Basket.GetBasket;

public class GetBasketQueryHandler(IBasketRepository basketRepository) : IRequestHandler<GetBasketQuery, ShoppingCart>
{
    public async Task<ShoppingCart> Handle(GetBasketQuery request, CancellationToken ct)
    {
        var shoppingCart = await basketRepository.GetBasketAsync(request.UserName, ct);

        if(shoppingCart is null) throw new BasketException($"basket with name : ({request.UserName}) not found");
        
        return shoppingCart;
    }
}