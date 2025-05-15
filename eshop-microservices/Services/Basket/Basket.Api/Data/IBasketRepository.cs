namespace Basket.Api.Data;

public interface IBasketRepository
{
 Task<ShoppingCart?> GetBasketAsync(string userName, CancellationToken ct);
 Task<ShoppingCart> StoreBasketAsync(ShoppingCart basket, CancellationToken cancellationToken);
 Task<bool> DeleteBasketAsync(string userName, CancellationToken cancellationToken);
}