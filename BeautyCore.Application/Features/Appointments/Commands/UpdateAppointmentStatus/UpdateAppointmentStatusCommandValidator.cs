using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Appointments.Commands.UpdateAppointmentStatus
{
    public class UpdateAppointmentStatusCommandValidator:AbstractValidator<UpdateAppointmentStatusCommand>
    {
        public UpdateAppointmentStatusCommandValidator()
        {
            RuleFor(x => x.AppointmentId).NotEmpty().WithMessage("Randevu Id boş olamaz.");
            RuleFor(x => x.NewStatus).IsInEnum().WithMessage("Geçersiz randevu durumu.");
        }
    }
}
