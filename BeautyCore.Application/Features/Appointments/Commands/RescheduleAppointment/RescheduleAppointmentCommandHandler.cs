using BeautyCore.Domain.Enums;
using BeautyCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Appointments.Commands.RescheduleAppointment;

public class RescheduleAppointmentCommandHandler : IRequestHandler<RescheduleAppointmentCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public RescheduleAppointmentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(RescheduleAppointmentCommand request, CancellationToken cancellationToken)
    {
        // 1. Randevuyu hizmet bilgisiyle birlikte getir
        var appointment = await _context.Appointments
            .Include(a => a.Service)
            .FirstOrDefaultAsync(a => a.Id == request.AppointmentId, cancellationToken);

        if (appointment == null)
            throw new KeyNotFoundException("Randevu bulunamadı.");

        if (appointment.Status == AppointmentStatus.Cancelled)
            throw new InvalidOperationException("İptal edilmiş bir randevunun tarihi değiştirilemez.");

        // 2. Yeni başlangıç ve bitiş zamanlarını hesapla
        var newStartUtc = DateTime.SpecifyKind(request.NewStartAtUtc, DateTimeKind.Utc);

        if (newStartUtc <= DateTime.UtcNow)
            throw new InvalidOperationException("Randevu saati geçmiş bir zamana alınamaz.");

        var durationMinutes = appointment.Service?.DurationMinutes ?? 30;
        var newEndUtc = newStartUtc.AddMinutes(durationMinutes);

        // 3. Personelin yeni gündeki mesai ve mola kontrolü
        var dayOfWeek = newStartUtc.DayOfWeek;
        var workingHour = await _context.StaffWorkingHours
            .AsNoTracking()
            .FirstOrDefaultAsync(w => w.StaffId == appointment.StaffId && w.Day == dayOfWeek, cancellationToken);

        if (workingHour == null)
            throw new InvalidOperationException("Personelin seçilen gün için çalışma saati bulunmamaktadır.");

        var startTimeOfDay = newStartUtc.TimeOfDay;
        var endTimeOfDay = newEndUtc.TimeOfDay;

        if (startTimeOfDay < workingHour.ShiftStartTime || endTimeOfDay > workingHour.ShiftEndTime)
            throw new InvalidOperationException("Seçilen saat personelin mesai saatleri dışındadır.");

        // Mola kontrolü
        if (workingHour.BreakStartTime.HasValue && workingHour.BreakEndTime.HasValue)
        {
            var breakStart = workingHour.BreakStartTime.Value;
            var breakEnd = workingHour.BreakEndTime.Value;

            bool isInBreak = startTimeOfDay < breakEnd && endTimeOfDay > breakStart;
            if (isInBreak)
                throw new InvalidOperationException("Seçilen saat personelin mola aralığına denk gelmektedir.");
        }

        // 4. Diğer randevularla çakışma kontrolü (Kendisi hariç)
        bool hasConflict = await _context.Appointments
            .AnyAsync(a => a.StaffId == appointment.StaffId
                        && a.Id != appointment.Id
                        && a.Status != AppointmentStatus.Cancelled
                        && newStartUtc < a.EndAtUtc
                        && newEndUtc > a.StartAtUtc, cancellationToken);

        if (hasConflict)
            throw new InvalidOperationException("Personelin seçilen saatte başka bir randevusu bulunmaktadır.");

        // 5. Randevu saatlerini güncelle ve kaydet
        appointment.StartAtUtc = newStartUtc;
        appointment.EndAtUtc = newEndUtc;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
