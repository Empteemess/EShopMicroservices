namespace Basket.Api.Basket.DeleteBasket;

public class DeleteBasketCommandHandler(IBasketRepository basketRepository) : IRequestHandler<DeleteBasketCommand, bool>
{
    public async Task<bool> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
    {
        var removeBasket = await basketRepository.DeleteBasketAsync(request.UserName, cancellationToken);
        
        if(!removeBasket) throw new BasketException("basket cant be deleted");
        
        return removeBasket;
    }
}