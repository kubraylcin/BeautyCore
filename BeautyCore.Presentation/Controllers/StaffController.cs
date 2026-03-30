using BeautyCore.Application.Features.Staff.Commands.AssignServices;
using BeautyCore.Application.Features.Staff.Commands.CreateStaff;
using BeautyCore.Application.Features.Staff.Queries.GetStaffByBranch;
using Microsoft.AspNetCore.Mvc;

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
    }
}
