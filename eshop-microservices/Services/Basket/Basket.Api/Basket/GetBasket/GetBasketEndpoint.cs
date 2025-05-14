namespace Basket.Api.Basket.GetBasket;

public class GetBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{UserName}", async (string userName, ISender sender) =>
        {
            var query = new GetBasketQuery(userName);

            var shoppingCart = await sender.Send(query);

            return Results.Ok(shoppingCart);
        })
        .WithName("GetBasket")
        .Produces<ShoppingCart>()
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get a basket by user name");
    }
}