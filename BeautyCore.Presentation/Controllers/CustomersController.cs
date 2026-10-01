using BeautyCore.Application.Features.Customers.Commands.CreateCustomer;
using BeautyCore.Application.Features.Customers.Queries.GetAllCustomers;
using BeautyCore.Application.Features.Customers.Queries.GetCustomerAppointments;
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

        // Yeni eklenen endpoint: Müşterinin randevularını getirir
        [HttpGet("{customerId:guid}/appointments")]
        public async Task<IActionResult> GetAppointments([FromRoute] Guid customerId)
        {
            var query = new GetCustomerAppointmentsQuery(customerId);
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
