namespace Catalog.Api.Exceptions;

public class ProductNotFoundException : Exception
{
    private static string? _message;

    public ProductNotFoundException() : base("Product not found")
    {
    }

    public ProductNotFoundException(Guid productId) : base(_message)
    {
        _message = $"Product with Id : ({productId}) not found";
    }
    
    
    public ProductNotFoundException(string message) : base(_message)
    {
        _message = message;
    }
};