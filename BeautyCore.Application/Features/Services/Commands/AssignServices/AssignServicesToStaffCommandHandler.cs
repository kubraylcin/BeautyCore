using BeautyCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BeautyCore.Application.Features.Staff.Commands.AssignServices;

public class AssignServicesToStaffCommandHandler : IRequestHandler<AssignServicesToStaffCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public AssignServicesToStaffCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(AssignServicesToStaffCommand request, CancellationToken cancellationToken)
    {
        // 1. Personeli mevcut hizmetleriyle birlikte getir (Many-to-Many ilişkisi için Include şart)
        var staff = await _context.Staffs
            .Include(x => x.Services)
            .FirstOrDefaultAsync(x => x.Id == request.StaffId, cancellationToken);

        if (staff == null) throw new Exception("Personel bulunamadı!");

        // 2. Atanacak hizmetleri veritabanından bul
        var servicesToAdd = await _context.Services
            .Where(s => request.ServiceIds.Contains(s.Id))
            .ToListAsync(cancellationToken);

        // 3. Mevcut hizmetleri temizle ve yenilerini ekle (Veya sadece farkı ekle)
        staff.Services.Clear(); // Öncekileri siliyoruz (Güncelleme mantığı)
        foreach (var service in servicesToAdd)
        {
            staff.Services.Add(service);
        }

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
