using BeautyCore.Application.Features.Appointments.Commands;
using BeautyCore.Application.Features.Appointments.Commands.UpdateAppointmentStatus;
using BeautyCore.Application.Features.Appointments.Queries.GetAppointmentsByBranch;
using BeautyCore.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace BeautyCore.Presentation.Controllers
{
    public class AppointmentsController : ApiBaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateAppointmentCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("branch/{branchId}")]
        public async Task<IActionResult>GetByBranch(Guid branchId)
        {
            return Ok(await Mediator.Send(new GetAppointmentsByBranchQuery(branchId)));
        }

        [HttpPatch("{appointmentId}/status")]
        public async Task<IActionResult> UpdateStatus(Guid appointmentId, [FromBody] AppointmentStatus status)
            {
            var command = new UpdateAppointmentStatusCommand(appointmentId,status);
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
