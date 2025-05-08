namespace Catalog.Api.Products.UpdateProduct;

public record UpdateProductCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ImageFile { get; set; }
    public List<string>? Category { get; set; } = [];
    public decimal Price { get; set; }
}
    
