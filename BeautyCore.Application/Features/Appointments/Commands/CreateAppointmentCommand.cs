using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Appointments.Commands
{
    public record CreateAppointmentCommand
    (
        Guid CustomerId,
        Guid StaffId,
        Guid ServiceId,
        Guid BranchId,
        DateTime StartAtUtc,
        string Note):IRequest<Guid>;
        
}
