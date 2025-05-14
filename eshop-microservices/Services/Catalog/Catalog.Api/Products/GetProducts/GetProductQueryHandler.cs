using Marten.Pagination;

namespace Catalog.Api.Products.GetProducts;

public class GetProductQueryHandler(IDocumentSession session) : IRequestHandler<GetProductQuery, IEnumerable<Product>>
{
    public async Task<IEnumerable<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>().ToPagedListAsync(request.PageNumber,request.PageSize, cancellationToken);

        return products;
    }
}