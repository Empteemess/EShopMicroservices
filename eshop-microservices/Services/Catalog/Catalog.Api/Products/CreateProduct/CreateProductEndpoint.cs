namespace Catalog.Api.Products.CreateProduct;

public class CreateProductEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products", async (CreateProductCommand command, IMediator mediator) =>
        {
            var productId = await mediator.Send(command);
            
            return Results.Created($"/products/{productId}", new {Id = productId});
        })
        .WithName("CreateProduct")
        .Produces<Guid>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest)
        .WithTags("Products");
    }
}