using Core.Dtos;
using FluentValidation;

namespace Core.Validator
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage("Email Boş Olamaz!")
                 .EmailAddress().WithMessage("Geçersiz Email Adresi!");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("İsim boş olamaz!");
            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Soyisim boş olamaz!");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre Boş olamaz")
                .MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır!");
        }
    }
}
