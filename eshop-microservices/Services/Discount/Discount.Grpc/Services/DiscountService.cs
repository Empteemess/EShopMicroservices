using Discount.Grpc.Models;
using Grpc.Core;
using DiscountException = Discount.Grpc.Exceptions.DiscountException;

namespace Discount.Grpc.Services;

public class DiscountService(DiscountContext dbContext) : DiscountProtoService.DiscountProtoServiceBase
{
    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var coupon = await dbContext.Coupons.FirstOrDefaultAsync(x => x.ProductName == request.ProductName) ??
                     new Coupon { ProductName = "No Discount", Description = "No Discount", Amount = 0 };

        return new CouponModel
        {
            ProductName = coupon.ProductName,
            Description = coupon.Description,
            Amount = coupon.Amount
        };
    }

    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var coupon = new Coupon
        {
            ProductName = request.Coupon.ProductName,
            Description = request.Coupon.Description,
            Amount = request.Coupon.Amount
        };

        dbContext.Add(coupon);
        await dbContext.SaveChangesAsync();

        return new CouponModel
        {
            Id = coupon.Id,
            ProductName = coupon.ProductName,
            Description = coupon.Description,
            Amount = coupon.Amount
        };
    }

    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var couponId = request.Coupon.Id;

        var coupon = await dbContext.Coupons.FirstOrDefaultAsync(x => x.Id == couponId);

        if (coupon is null)
            throw new DiscountException();

        coupon.ProductName = request.Coupon.ProductName;
        coupon.Description = request.Coupon.Description;
        coupon.Amount = request.Coupon.Amount;

        dbContext.Update(coupon);
        await dbContext.SaveChangesAsync();

        return new CouponModel
        {
            Id = coupon.Id,
            ProductName = coupon.ProductName,
            Description = coupon.Description,
            Amount = coupon.Amount
        };
    }

    public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request,
        ServerCallContext context)
    {
        var productName = request.ProductName;

        var discount = await dbContext.Coupons.FirstOrDefaultAsync(x => x.ProductName == productName);

        if (discount is null)
            throw new DiscountException();

        dbContext.Remove(discount);
        await dbContext.SaveChangesAsync();

        return new DeleteDiscountResponse { Success = true };
    }
}