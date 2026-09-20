using BeautyCore.Domain.Entities;
using BeautyCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Staff.Commands.SetWorkingHours;

public class SetStaffWorkingHoursCommandHandler : IRequestHandler<SetStaffWorkingHoursCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public SetStaffWorkingHoursCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(SetStaffWorkingHoursCommand request, CancellationToken cancellationToken)
    {
        // 1. Personel var mı kontrol et
        var staffExists = await _context.Staffs
            .AnyAsync(s => s.Id == request.StaffId, cancellationToken);

        if (!staffExists)
            throw new KeyNotFoundException("Belirtilen personel sistemde bulunamadı.");

        // 2. Personelin mevcut tüm çalışma saatlerini getir
        var existingHours = await _context.StaffWorkingHours
            .Where(w => w.StaffId == request.StaffId)
            .ToListAsync(cancellationToken);

        // 3. Mevcut saatleri kaldır
        if (existingHours.Any())
        {
            _context.StaffWorkingHours.RemoveRange(existingHours);
        }

        // 4. Yeni saatleri listeye dönüştürüp ekle
        var newWorkingHours = request.WorkingHours.Select(dto => new StaffWorkingHour
        {
            StaffId = request.StaffId,
            Day = dto.Day,
            ShiftStartTime = dto.ShiftStartTime,
            ShiftEndTime = dto.ShiftEndTime,
            BreakStartTime = dto.BreakStartTime,
            BreakEndTime = dto.BreakEndTime
        }).ToList();

        await _context.StaffWorkingHours.AddRangeAsync(newWorkingHours, cancellationToken);

        // 5. Değişiklikleri kaydet
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
