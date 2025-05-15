using Microsoft.Extensions.Caching.Distributed;

namespace Basket.Api.Data;

public class CachedBasketRepository(IBasketRepository repository, IDistributedCache cache)
    : IBasketRepository
{
    public async Task<ShoppingCart?> GetBasketAsync(string userName, CancellationToken ct)
    {
        var cachedBasket = await cache.GetStringAsync(userName, ct);

        if (!string.IsNullOrWhiteSpace(cachedBasket))
            return JsonSerializer.Deserialize<ShoppingCart>(cachedBasket);

        var basket = await repository.GetBasketAsync(userName, ct) ??
                     throw new BasketException(userName);

        var serializedBasket = JsonSerializer.Serialize(basket);

        await cache.SetStringAsync(userName, serializedBasket, ct);

        return basket;
    }

    public async Task<ShoppingCart> StoreBasketAsync(ShoppingCart basket, CancellationToken cancellationToken)
    {
        var shoppingCart = await repository.StoreBasketAsync(basket, cancellationToken);

        var cachedBasket = JsonSerializer.Serialize(basket);

        await cache.SetStringAsync(shoppingCart.UserName!, cachedBasket, cancellationToken);

        return shoppingCart;
    }

    public async Task<bool> DeleteBasketAsync(string userName, CancellationToken cancellationToken)
    {
        var isDeleted = await repository.DeleteBasketAsync(userName, cancellationToken);

        if (isDeleted)
            await cache.RemoveAsync(userName, cancellationToken);

        return isDeleted;
    }
}