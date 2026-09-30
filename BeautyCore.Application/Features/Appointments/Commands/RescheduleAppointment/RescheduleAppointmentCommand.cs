using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Appointments.Commands.RescheduleAppointment
{
    public record RescheduleAppointmentCommand
    (
        Guid AppointmentId,
        DateTime NewStartAtUtc):IRequest<bool>;
}
