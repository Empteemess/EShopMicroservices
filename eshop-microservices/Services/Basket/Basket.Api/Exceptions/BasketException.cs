namespace Basket.Api.Exceptions;

public class BasketException : Exception
{
    private static string? _message;

    public BasketException() : base("Basket not found")
    {
    }

    public BasketException(Guid basketName) : base(_message)
    {
        _message = $"Basket with name : ({basketName}) not found";
    }
    
    public BasketException(string message) : base(_message)
    {
        _message = message;
    }
}