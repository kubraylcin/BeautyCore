using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Notifications.Queries.GetCustomerNotifications
{
    public class NotificationDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string Message { get; set; } = default!;
        public bool IsRead { get; set; }
        public string Type { get; set; } = default!;
        public DateTime CreatedAtUtc { get; set; }
    }
}
