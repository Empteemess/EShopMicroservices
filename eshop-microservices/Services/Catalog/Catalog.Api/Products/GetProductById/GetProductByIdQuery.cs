namespace Catalog.Api.Products.GetProductById;

public record GetProductByIdQuery(Guid Id) : IRequest<Product>;
