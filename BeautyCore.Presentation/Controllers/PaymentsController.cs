using BeautyCore.Application.Features.Payments.Commands.CreatePayment;
using Microsoft.AspNetCore.Mvc;

namespace BeautyCore.Presentation.Controllers
{
    public class PaymentsController: ApiBaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePaymentCommand command)
        {
            var paymentId = await Mediator.Send(command);
            return Ok(new { PaymentId = paymentId, Message = "Ödeme başarıyla alındı ve kaydedildi." });
        }
    }
}
