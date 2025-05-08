namespace Catalog.Api.Products.DeleteProductById;

public record DeleteProductByIdCommand(Guid Id) : IRequest<bool>;
