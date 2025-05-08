namespace Catalog.Api.Products.GetProductById;

public class GetProductQueryHandler(IDocumentSession session) : IRequestHandler<GetProductByIdQuery, Product>
{
    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(request.Id, cancellationToken);
        
        if(product is null) throw new ProductNotFoundException(request.Id);
        
        return product;
    }
}