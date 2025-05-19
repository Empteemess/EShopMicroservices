using Basket.Api.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Basket.StoreBasket;

public class StoreBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket", async ([FromBody] StoreBasketCommand storeBasketCommand, ISender sender) =>
        {
            var result = await sender.Send(storeBasketCommand);

            return Results.Ok(result);
        })
            .WithName("StoreBasket")
            .Produces<ShoppingCart>()
            .ProducesProblem(StatusCodes.Status404NotFound);
    }
}