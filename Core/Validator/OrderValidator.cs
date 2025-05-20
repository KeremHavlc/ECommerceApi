using Core.Dtos;
using FluentValidation;

namespace Core.Validator
{
    public class OrderValidator : AbstractValidator<OrderDto>
    {
        public OrderValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("User Id cannot be empty");
            RuleFor(x => x.AddressId)
               .NotEmpty()
               .WithMessage("Address Id cannot be empty");
            RuleFor(x => x.Status)
              .NotEmpty()
              .WithMessage("Status cannot be empty");
        }
    }
}
