namespace Catalog.Api.Products.DeleteProductById;

public class DeleteProductByIdEndpoint : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/products/{id:guid}", async (Guid id, ISender sender) =>
        {
            var command = new DeleteProductByIdCommand(id);
            var result = await sender.Send(command);

            return new { Removed = result };
        });
    }
}