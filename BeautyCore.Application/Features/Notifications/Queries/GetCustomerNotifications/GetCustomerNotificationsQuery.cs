using BeautyCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Notifications.Queries.GetCustomerNotifications
{
    public record GetCustomerNotificationsQuery(Guid CustomerId) : IRequest<List<NotificationDto>>;

    public class GetCustomerNotificationsQueryHandler : IRequestHandler<GetCustomerNotificationsQuery, List<NotificationDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetCustomerNotificationsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<NotificationDto>> Handle(GetCustomerNotificationsQuery request, CancellationToken cancellationToken)
        {
            var notifications = await _context.Notifications
                .Where(n => n.CustomerId == request.CustomerId)
                .OrderByDescending(n => n.CreatedAtUtc)
                .Select(n => new NotificationDto
                {
                    Id = n.Id,
                    Title = n.Title,
                    Message = n.Message,
                    IsRead = n.IsRead,
                    Type = n.Type,
                    CreatedAtUtc = n.CreatedAtUtc
                })
                .ToListAsync(cancellationToken);

            return notifications;
        }
    }
}
