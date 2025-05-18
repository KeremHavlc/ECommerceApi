using Core.Dtos;
using FluentValidation;

namespace Core.Validator
{
    public class AddressValidator : AbstractValidator<AddressDto>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title cannot be empty")
                .Length(3, 400)
                .WithMessage("Title must be between 3 and 400 characters");
            RuleFor(x => x.Destrict)
               .NotEmpty()
               .WithMessage("Destrict cannot be empty")
               .Length(3, 400)
               .WithMessage("Destrict must be between 3 and 400 characters");
            RuleFor(x => x.Street)
               .NotEmpty()
               .WithMessage("Street cannot be empty!")
               .Length(3,400)
               .WithMessage("Street must be between 3 and 400 characters");
            RuleFor(x=>x.City)
                .NotEmpty()
                .WithMessage("City cannot be empty")
                .Length(3 , 400)
                .WithMessage("City must be between 3 and 400 characters");
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("User Id cannot be empty");
        }
    }
}
