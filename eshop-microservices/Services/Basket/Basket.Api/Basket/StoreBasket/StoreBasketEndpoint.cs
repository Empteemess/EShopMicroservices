namespace Basket.Api.Basket.StoreBasket;

public class StoreBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket/{userName}", async (string userName, ISender sender) =>
        {
            var shoppingCart = new ShoppingCart(userName);

            var command = new StoreBasketCommand(shoppingCart);

            var result = await sender.Send(command);

            return Results.Ok(result);
        })
            .WithName("StoreBasket")
            .Produces<ShoppingCart>()
            .ProducesProblem(StatusCodes.Status404NotFound);
    }
}