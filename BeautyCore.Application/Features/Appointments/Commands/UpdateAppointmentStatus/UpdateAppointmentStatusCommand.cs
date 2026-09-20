using BeautyCore.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Appointments.Commands.UpdateAppointmentStatus
{
    public record UpdateAppointmentStatusCommand
    (
        Guid AppointmentId,
        AppointmentStatus NewStatus):IRequest<bool>;
}
