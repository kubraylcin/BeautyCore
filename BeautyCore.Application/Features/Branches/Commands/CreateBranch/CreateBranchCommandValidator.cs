using FluentValidation;

namespace BeautyCore.Application.Features.Branches.Commands.CreateBranch;

public class CreateBranchCommandValidator : AbstractValidator<CreateBranchCommand>
{
    public CreateBranchCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Şube adı boş olamaz.")
            .MinimumLength(3).WithMessage("Şube adı en az 3 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Şube adı 100 karakterden fazla olamaz.");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Şube adresi boş olamaz.")
            .MaximumLength(500).WithMessage("Adres çok uzun.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Telefon numarası zorunludur.")
            .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Geçerli bir telefon numarası giriniz.");
        // Bu regex, uluslararası formatta telefon numarası kontrolü yapar.
    }
}
