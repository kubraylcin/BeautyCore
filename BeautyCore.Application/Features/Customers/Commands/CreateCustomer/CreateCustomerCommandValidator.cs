using BeautyCore.Domain.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BeautyCore.Application.Features.Customers.Commands.CreateCustomer;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateCustomerCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Müşteri adı zorunludur.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Müşteri soyadı zorunludur.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email adresi zorunludur.")
            .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.")
            // 👇 İşte burası veritabanı kontrolü yapar
            .MustAsync(BeUniqueEmail).WithMessage("Bu email adresi zaten sisteme kayıtlı.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Telefon numarası zorunludur.")
            .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Geçerli bir telefon formatı giriniz.")
            // İstersen aynısını telefon için de yapabilirsin:
            .MustAsync(BeUniquePhone).WithMessage("Bu telefon numarası zaten sisteme kayıtlı.");
    }

    // Email kontrolü yapan yardımcı fonksiyon
    private async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
    {
        // Veritabanında bu maille biri var mı bakıyoruz
        var exists = await _context.Customers
            .AnyAsync(x => x.Email == email, cancellationToken);

        // Eğer varsa 'false' döneriz (yani kural ihlal edilir), yoksa 'true'
        return !exists;
    }

    // Telefon kontrolü yapan yardımcı fonksiyon
    private async Task<bool> BeUniquePhone(string phone, CancellationToken cancellationToken)
    {
        var exists = await _context.Customers
            .AnyAsync(x => x.PhoneNumber == phone, cancellationToken);

        return !exists;
    }
}
