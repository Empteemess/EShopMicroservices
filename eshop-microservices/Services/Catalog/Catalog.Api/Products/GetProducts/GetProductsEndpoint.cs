namespace Catalog.Api.Products.GetProducts;

public class GetProductsEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (int pageNumber, int pageSize, ISender sender) =>
            {
                var query = new GetProductQuery(pageNumber, pageSize);

                var products = await sender.Send(query);

                return Results.Ok(products);
            })
            .WithName("GetProducts")
            .Produces<IEnumerable<Product>>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get a list of products")
            .WithDescription("Get a list of products");
    }
}