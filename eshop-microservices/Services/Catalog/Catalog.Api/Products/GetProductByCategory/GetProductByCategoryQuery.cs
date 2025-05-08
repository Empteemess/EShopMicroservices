namespace Catalog.Api.Products.GetProductByCategory;

public record GetProductByCategoryQuery(string CategoryName) : IRequest<IEnumerable<Product>>;
    
