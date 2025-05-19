namespace Catalog.Api.Products.CreateProduct;

public class CreateProductCommand : IRequest<Guid>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ImageFile { get; set; }
    public IEnumerable<string> Category { get; set; } = [];
    public decimal Price { get; set; }
}