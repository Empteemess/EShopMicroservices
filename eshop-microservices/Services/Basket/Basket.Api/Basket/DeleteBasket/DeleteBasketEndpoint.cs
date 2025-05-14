namespace Basket.Api.Basket.DeleteBasket;

public class DeleteBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/basket/{UserName}", async (string userName, ISender sender) =>
        {
            var command = new DeleteBasketCommand(userName);

            var result = await sender.Send(command);

            return result ? Results.NoContent() : Results.NotFound();
        }).WithName("DeleteBasket")
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Delete a basket by user name");
    }
}