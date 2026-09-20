using BeautyCore.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BeautyCore.Application.Features.Appointments.Commands.UpdateAppointmentStatus
{
    public class UpdateAppointmentStatusCommandHandler : IRequestHandler<UpdateAppointmentStatusCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        public UpdateAppointmentStatusCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(UpdateAppointmentStatusCommand request, CancellationToken cancellationToken)
        {
            var appointment = await _context.Appointments
                .FirstOrDefaultAsync(a => a.Id == request.AppointmentId, cancellationToken);
            if (appointment == null)
            {               
                throw new KeyNotFoundException("Güncellenmek istenen randevu bulunamadı");
            }
            appointment.Status = request.NewStatus;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
