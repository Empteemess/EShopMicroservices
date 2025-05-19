using Discount.Grpc;

namespace Basket.Api.Basket.StoreBasket;

public class StoreBasketCommandHandler(
    IBasketRepository basketRepository,
    DiscountProtoService.DiscountProtoServiceClient discountProto) : IRequestHandler<StoreBasketCommand, string>
{
    public async Task<string> Handle(StoreBasketCommand request, CancellationToken cancellationToken)
    {
        var shoppingCart = new ShoppingCart
        {
            UserName = request.UserName,
            Items = request.Items?.Select(item => new ShoppingCartItem
            {
                ProductName = item.ProductName,
                Price = item.Price,
                Quantity = item.Quantity,
                Color = item.Color,
                ProductId = Guid.NewGuid()
            }).ToList()
        };

        foreach (var item in shoppingCart.Items)
        {
            var coupon =
                await discountProto.GetDiscountAsync(new GetDiscountRequest { ProductName = item.ProductName });
            
            item.Price -= item.Price * coupon.Amount / 100;
        }

        var storedBasket = await basketRepository.StoreBasketAsync(shoppingCart, cancellationToken);

        return storedBasket.UserName ?? string.Empty;
    }
}