using BeautyCore.Domain.Enums;
using BeautyCore.Domain.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Appointments.Commands
{
    public class CreateAppointmentCommandValidator: AbstractValidator<CreateAppointmentCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateAppointmentCommandValidator(IApplicationDbContext context)
        {
            _context = context;
            RuleFor(x => x.StartAtUtc)
            .GreaterThan(DateTime.UtcNow).WithMessage("Geçmiş bir tarihe randevu alınamaz.");

            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.StaffId).NotEmpty();
            RuleFor(x => x.ServiceId).NotEmpty();
            RuleFor(x => x.BranchId).NotEmpty();

            // Personel uygunluk kontrolü
            RuleFor(x => x)
                .MustAsync(BeStaffAvailable).WithMessage("Seçilen personel belirtilen saat aralığında dolu.");
        }

        private async Task<bool> BeStaffAvailable(CreateAppointmentCommand command, CancellationToken cancellationToken)
        {
            var service = await _context.Services.AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == command.ServiceId, cancellationToken);

            if (service == null) return false;

            var start = command.StartAtUtc;
            var end = command.StartAtUtc.AddMinutes(service.DurationMinutes);

            // Çakışma algoritması: (Mevcut Başlangıç < Yeni Bitiş) VE (Mevcut Bitiş > Yeni Başlangıç)
            var isBusy = await _context.Appointments.AnyAsync(a =>
                a.StaffId == command.StaffId &&
                a.BranchId == command.BranchId &&
                (a.Status == AppointmentStatus.Pending || a.Status == AppointmentStatus.Confirmed) &&
                a.StartAtUtc < end &&
                a.EndAtUtc > start,
                cancellationToken);

            return !isBusy;
        }
    }
}
