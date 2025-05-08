namespace Catalog.Api.Products.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IDocumentSession _session;

    public CreateProductCommandHandler(IDocumentSession session)
    {
        _session = session;
    }

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = request.Adapt<Product>();
        product.Id = Guid.NewGuid();

        _session.Store(product);
        await _session.SaveChangesAsync(cancellationToken);

        return product.Id;
    }
}