namespace Catalog.Api.Products.UpdateProduct;

public class UpdateProductEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/products", async (UpdateProductCommand command, ISender sender) =>
        {
            var update = await sender.Send(command);

            return new { Updated = update };
        });
    }
}