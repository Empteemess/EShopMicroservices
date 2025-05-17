namespace Discount.Grpc.Exceptions;

public class DiscountException : Exception
{
    private static string? _message;

    public DiscountException() : base("Discount not found")
    {
    }

    public DiscountException(Guid productId) : base(_message)
    {
        _message = $"Discount with Id : ({productId}) not found";
    }
    
    
    public DiscountException(string message) : base(_message)
    {
        _message = message;
    }
};