using BeautyCore.Application.Features.Services.Commands.CreateService;
using BeautyCore.Application.Features.Services.Queries.GetAllServices;
using Microsoft.AspNetCore.Mvc;

namespace BeautyCore.Presentation.Controllers
{
    public class ServicesController : ApiBaseController
    {
        [HttpPost]
        public async Task<IActionResult>Create(CreateServiceCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllServicesQuery()));
        }
    }
}
