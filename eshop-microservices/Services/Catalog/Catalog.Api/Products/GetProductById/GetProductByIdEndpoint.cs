namespace Catalog.Api.Products.GetProductById;

public class GetProductByIdEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id:guid}", async (ISender sender, Guid id) =>
            {
                var query = new GetProductByIdQuery(id);
                var product = await sender.Send(query);

                return product;
            })
            .WithName("GetProductById")
            .Produces<Product>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get a product by id")
            .WithDescription("Get a product by id");
    }
}