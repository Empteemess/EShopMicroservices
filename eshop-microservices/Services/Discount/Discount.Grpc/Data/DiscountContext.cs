using Discount.Grpc.Models;

namespace Discount.Grpc.Data;

public class DiscountContext : DbContext
{
    public DbSet<Coupon> Coupons { get; set; }

    public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Coupon>().Property(x => x.Id).ValueGeneratedOnAdd();

        modelBuilder.Entity<Coupon>().HasData(
            new Coupon { Id = 1, ProductName = "ProdName1", Description = "Desc1", Amount = 10 },
            new Coupon { Id = 2, ProductName = "ProdName2", Description = "Desc2", Amount = 20 },
            new Coupon { Id = 3, ProductName = "ProdName3", Description = "Desc3", Amount = 30 });
    }
}