namespace Catalog.Api.Products.DeleteProductById;

public class DeleteProductByIdCommandHandler(IDocumentSession session) : IRequestHandler<DeleteProductByIdCommand, bool>
{
    public async Task<bool> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(request.Id, cancellationToken);
        
        if (product is null) throw new ProductNotFoundException(request.Id);
        
        session.Delete<Product>(request.Id);
        await session.SaveChangesAsync(cancellationToken);
        
        return true;
    }
}