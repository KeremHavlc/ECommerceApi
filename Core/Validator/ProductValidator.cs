using Core.Dtos;
using FluentValidation;

namespace Core.Validator
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ürün Adı Boş Olamaz!")
                .MinimumLength(3).WithMessage("Ürün Adı en az 3 karakter olmalıdır!");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Ürün Açıklaması Boş Olamaz!")
                .MinimumLength(7).WithMessage("Ürün Açıklaması en az 7 karakter olmalıdır!");
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Fiyat Boş Olamaz!")
                .GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır!");
            RuleFor(x => x.Image)
                .NotEmpty().WithMessage("Resim Boş Olamaz!");
            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Kategori ID Boş Olamaz!");
        }
    }
}
