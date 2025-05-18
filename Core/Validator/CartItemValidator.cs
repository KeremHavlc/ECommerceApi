using Core.Dtos;
using FluentValidation;

namespace Core.Validator
{
    public class CartItemValidator : AbstractValidator<CartItemDto>
    {
        public CartItemValidator()
        {
            RuleFor(x=>x.UserId).NotEmpty().WithMessage("User Id cannot be empty");
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product Id cannot be empty");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0");
        }
    }
}
