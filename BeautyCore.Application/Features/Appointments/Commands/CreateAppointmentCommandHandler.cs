using BeautyCore.Domain.Entities;
using BeautyCore.Domain.Enums;
using BeautyCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Appointments.Commands
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, Guid>
    {
        public IApplicationDbContext _context;

        public CreateAppointmentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            // 1. Hizmet bilgilerini çek (Süreyi ve fiyatı öğrenmek için)
            var service = await _context.Services
                .FirstOrDefaultAsync(s=>s.Id==request.ServiceId, cancellationToken);

            if (service == null) throw new Exception("Hizmet bulunamadı ");

            // 2. Randevuyu oluştur
            var appointment = new Appointment
            {
                CustomerId = request.CustomerId,
                StaffId = request.StaffId,
                ServiceId = request.ServiceId,
                BranchId = request.BranchId,
                StartAtUtc = request.StartAtUtc,
                EndAtUtc = request.StartAtUtc.AddMinutes(service.DurationMinutes),// Bitiş saati = Başlangıç + Hizmet Süresi
                TotalPrice = service.Price,// O anki hizmet fiyatını sabitle
                Note = request.Note,
                Status = AppointmentStatus.Pending
            };
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync(cancellationToken);
            return appointment.Id;
        }
    }
}
