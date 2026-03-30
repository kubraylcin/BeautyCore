using FluentValidation;

namespace BeautyCore.Application.Features.Services.Commands.CreateService;

public class CreateServiceCommandValidator : AbstractValidator<CreateServiceCommand>
{
    public CreateServiceCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Hizmet adı boş olamaz.")
            .MinimumLength(2).WithMessage("Hizmet adı en az 2 karakter olmalıdır.")
            .MaximumLength(150).WithMessage("Hizmet adı 150 karakterden fazla olamaz.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama 500 karakteri geçmemelidir.");

        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("Fiyat alanı zorunludur.")
            .GreaterThan(0).WithMessage("Hizmet fiyatı 0'dan büyük olmalıdır.");

        RuleFor(x => x.DurationMinutes)
            .NotEmpty().WithMessage("Hizmet süresi belirtilmelidir.")
            .InclusiveBetween(5, 480).WithMessage("Hizmet süresi 5 dakika ile 8 saat (480 dk) arasında olmalıdır.");
    }
}
