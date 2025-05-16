using Core.Dtos;
using FluentValidation;

namespace Core.Validator
{
    public class CategoryValidator : AbstractValidator<CategoryDto>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Kategori Adı Boş Olamaz!")
                .MinimumLength(3).WithMessage("Kategori Adı en az 3 karakter olmalıdır!");
            RuleFor(x => x.CreatedAt)
                .NotEmpty().WithMessage("Oluşturulma Tarihi Boş Olamaz!");
        }
    }

}
