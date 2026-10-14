using BeautyCore.Application.Features.Notifications.Commands.CreateNotification;
using BeautyCore.Application.Features.Notifications.Queries.GetCustomerNotifications;
using Microsoft.AspNetCore.Mvc;

namespace BeautyCore.Presentation.Controllers
{
    public class NotificationsController: ApiBaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateNotificationCommand command)
        {
            var notificationId = await Mediator.Send(command);
            return Ok(new { NotificationId = notificationId, Message = "Bildirim başarıyla oluşturuldu." });
        }

        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<List<NotificationDto>>> GetByCustomer(Guid customerId)
        {
            var result = await Mediator.Send(new GetCustomerNotificationsQuery(customerId));
            return Ok(result);
        }
    }
}
