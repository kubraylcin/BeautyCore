// GetStaffAvailabilityQueryHandler.cs (fixed)
using BeautyCore.Domain.Enums;
using BeautyCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Staff.Queries.GetStaffAvailability
{
    public class GetStaffAvailabilityQueryHandler : IRequestHandler<GetStaffAvailabilityQuery, List<string>>
    {
        private readonly IApplicationDbContext _context;

        public GetStaffAvailabilityQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<string>> Handle(GetStaffAvailabilityQuery request, CancellationToken cancellationToken)
        {
            // 1. Hizmeti ve süresini doğrula
            var service = await _context.Services
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == request.ServiceId, cancellationToken);

            if (service == null)
            {
                throw new KeyNotFoundException("Seçilen hizmet sistemde bulunamadı.");
            }

            // 2. Personelin o günkü mesai ve mola saatlerini al
            var dayOfWeek = request.Date.DayOfWeek;
            var workingHour = await _context.StaffWorkingHours
                .AsNoTracking()
                .FirstOrDefaultAsync(w => w.StaffId == request.StaffId && w.Day == dayOfWeek, cancellationToken);

            // Personelin o gün mesai tanımı yoksa doğrudan boş liste dön
            if (workingHour == null)
            {
                return new List<string>();
            }

            // 3. O günün başlangıç ve bitiş UTC sınırlarını belirle (DateTime.Date ile sıfırlıyoruz)
            var baseDate = DateTime.SpecifyKind(request.Date.Date, DateTimeKind.Utc);
            var startOfDay = baseDate;
            var endOfDay = baseDate.AddDays(1).AddTicks(-1);

            // O günkü iptal edilmemiş randevuları çek
            var existingAppointments = await _context.Appointments
                .AsNoTracking()
                .Where(a => a.StaffId == request.StaffId
                         && a.Status != AppointmentStatus.Cancelled
                         && a.StartAtUtc >= startOfDay
                         && a.StartAtUtc <= endOfDay)
                .Select(a => new { a.StartAtUtc, a.EndAtUtc })
                .ToListAsync(cancellationToken);

            // 4. Slotları hesapla
            var availableSlots = new List<string>();

            var shiftStart = baseDate.Add(workingHour.ShiftStartTime);
            var shiftEnd = baseDate.Add(workingHour.ShiftEndTime);

            DateTime? breakStart = workingHour.BreakStartTime.HasValue
                ? baseDate.Add(workingHour.BreakStartTime.Value)
                : null;

            DateTime? breakEnd = workingHour.BreakEndTime.HasValue
                ? baseDate.Add(workingHour.BreakEndTime.Value)
                : null;

            var currentSlotStart = shiftStart;

            // Hizmet süresi kadar slot ilerleterek kontrol et
            while (currentSlotStart.AddMinutes(service.DurationMinutes) <= shiftEnd)
            {
                var currentSlotEnd = currentSlotStart.AddMinutes(service.DurationMinutes);

                // Mola saatine denk geliyor mu?
                bool isInBreak = false;
                if (breakStart.HasValue && breakEnd.HasValue)
                {
                    isInBreak = currentSlotStart < breakEnd.Value && currentSlotEnd > breakStart.Value;
                }

                // Mevcut randevulardan herhangi biriyle çakışıyor mu?
                bool isOverlapping = existingAppointments.Any(a =>
                    currentSlotStart < a.EndAtUtc && currentSlotEnd > a.StartAtUtc);

                // Mola ve randevu çakışması yoksa slot uygundur
                if (!isInBreak && !isOverlapping)
                {
                    availableSlots.Add(currentSlotStart.ToString("HH:mm"));
                }

                // Slot adımı: Her 30 dakikada bir yeni randevu başlatılabilir
                currentSlotStart = currentSlotStart.AddMinutes(30);
            }

            return availableSlots;
        }
    }
}
