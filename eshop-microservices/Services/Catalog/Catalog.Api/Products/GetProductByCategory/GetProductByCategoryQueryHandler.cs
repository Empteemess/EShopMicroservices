namespace Catalog.Api.Products.GetProductByCategory;

public class GetProductByCategoryQueryHandler(IDocumentSession session)
    : IRequestHandler<GetProductByCategoryQuery, IEnumerable<Product>>
{
    public async Task<IEnumerable<Product>> Handle(GetProductByCategoryQuery request,
        CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>()
            .Where(x => x.Category.Contains(request.CategoryName))
            .ToListAsync(token: cancellationToken);
        
        if (products.Count <= 0)
            throw new ProductNotFoundException($"Product with Category : ({request.CategoryName}) not found");

        return products;
    }
}