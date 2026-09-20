using BeautyCore.Application.Features.Staff.Commands.AssignServices;
using BeautyCore.Application.Features.Staff.Commands.CreateStaff;
using BeautyCore.Application.Features.Staff.Commands.SetWorkingHours;
using BeautyCore.Application.Features.Staff.Queries.GetStaffAvailability;
using BeautyCore.Application.Features.Staff.Queries.GetStaffByBranch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BeautyCore.Presentation.Controllers
{
    public class StaffController : ApiBaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateStaffCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("branch/{branchId}")]
        public async Task<IActionResult> GetByBranch(Guid branchId)
        {
            return Ok(await Mediator.Send(new GetStaffByBranchQuery(branchId)));
        }
        [HttpPost("assign-services")]
        public async Task<IActionResult> AssignServices(AssignServicesToStaffCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        [HttpGet("{staffId:guid}/availability")]
        public async Task<IActionResult> GetAvailability(
    [FromRoute] Guid staffId,
    [FromQuery][BindRequired] Guid serviceId,
    [FromQuery][BindRequired] DateTime date)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var query = new GetStaffAvailabilityQuery(staffId, serviceId, date);
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpPut("{staffId:guid}/working-hours")]
        public async Task<IActionResult> SetWorkingHours(
    [FromRoute] Guid staffId,
    [FromBody] List<WorkingHourDto> workingHours)
        {
            var command = new SetStaffWorkingHoursCommand(staffId, workingHours);
            var result = await Mediator.Send(command);
            return Ok(new { success = result, message = "Çalışma saatleri başarıyla güncellendi." });
        }
    }
}
