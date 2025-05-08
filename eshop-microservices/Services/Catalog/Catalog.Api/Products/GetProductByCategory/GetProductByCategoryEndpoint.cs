namespace Catalog.Api.Products.GetProductByCategory;

public class GetProductByCategoryEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/Category/{categoryName}", async (string categoryName, IMediator mediator) =>
        {
            var query = new GetProductByCategoryQuery(categoryName);
            
            var products = await mediator.Send(query);
            
            return Results.Ok(products);
        });
    }
}