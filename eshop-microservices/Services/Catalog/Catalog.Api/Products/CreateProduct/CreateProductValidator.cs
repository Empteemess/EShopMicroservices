using FluentValidation;

namespace Catalog.Api.Products.CreateProduct;

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Name)
            .NotNull().NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.")
            .MinimumLength(3).WithMessage("Name must be at least 3 characters long.")
            .Matches(@"^[a-zA-Z0-9\s]+$").WithMessage("Name can only contain letters, numbers, and spaces.");
        
        RuleFor(x => x.Description)
            .NotNull().NotEmpty().WithMessage("Description is required.")
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters.")
            .MinimumLength(10).WithMessage("Description must be at least 10 characters long.")
            .Matches(@"^[a-zA-Z0-9\s.,]+$").WithMessage("Description can only contain letters, numbers, spaces, and punctuation.");
        
        RuleFor(x => x.ImageFile)
            .NotNull().NotEmpty().WithMessage("ImageFile is required.")
            .Matches(@"^https?:\/\/.*\.(jpg|jpeg|png|gif)$").WithMessage("ImageFile must be a valid URL ending with .jpg, .jpeg, .png, or .gif.");
        
        RuleFor(x => x.Category)
            .NotNull().NotEmpty().WithMessage("Category is required.")
            .Must(x => x.Count() > 0).WithMessage("At least one category is required.")
            .Must(x => x.All(c => !string.IsNullOrWhiteSpace(c))).WithMessage("Category cannot contain empty or whitespace values.");
        
        RuleFor(x => x.Price)
            .NotNull().NotEmpty().WithMessage("Price is required.")
            .GreaterThan(0).WithMessage("Price must be greater than 0.")
            .LessThan(10000).WithMessage("Price must be less than 10,000.");
    }
}