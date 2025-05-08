namespace Catalog.Api.Products.UpdateProduct;

public class UpdateProductCommandHandler(IDocumentSession session) : IRequestHandler<UpdateProductCommand, bool>
{
    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(request.Id, cancellationToken);

        if (product is null) throw new ProductNotFoundException(request.Id);

        product.Name = request.Name ?? product.Name;
        product.Description = request.Description ?? product.Description;
        product.Price = request.Price;
        product.ImageFile = request.ImageFile ?? product.ImageFile;
        product.Category = request.Category?.Count >= 0 ? request.Category :product.Category;

        session.Update(product);
        await session.SaveChangesAsync(cancellationToken);
        
        return true;
    }
}