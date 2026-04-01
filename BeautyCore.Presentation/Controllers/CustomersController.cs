using BeautyCore.Application.Features.Customers.Commands.CreateCustomer;
using BeautyCore.Application.Features.Customers.Queries.GetAllCustomers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeautyCore.Presentation.Controllers
{
    public class CustomersController : ApiBaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await Mediator.Send(new GetAllCustomersQuery());
            return Ok(response);
        }
    }
}
