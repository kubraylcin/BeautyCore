using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Notifications.Commands.CreateNotification
{
    public record CreateNotificationCommand(
    Guid CustomerId,
    string Title,
    string Message,
    string Type) : IRequest<Guid>;
}
