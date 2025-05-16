using System.ComponentModel.DataAnnotations;

namespace Discount.Grpc.Models;

public class Coupon
{
    [Key]
    public int Id { get; set; }
    public required string ProductName { get; set; }
    public string? Description { get; set; }
    public int Amount { get; set; }
}