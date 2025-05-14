namespace Catalog.Api.Products.GetProducts;

public record GetProductQuery(int PageNumber = 1,int PageSize = 5) : IRequest<IEnumerable<Product>>;
        
