using BeautyCore.Domain.Entities;
using BeautyCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Notifications.Commands.CreateNotification
{
    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateNotificationCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            // Müşteri sistemde var mı kontrol ediyoruz
            var customerExists = await _context.Customers
                .AnyAsync(c => c.Id == request.CustomerId, cancellationToken);

            if (!customerExists)
                throw new KeyNotFoundException("Bildirim gönderilmek istenen müşteri bulunamadı.");

            var notification = new Notification
            {
                CustomerId = request.CustomerId,
                Title = request.Title,
                Message = request.Message,
                IsRead = false,
                Type = request.Type
            };

            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync(cancellationToken);

            return notification.Id;
        }
    }
}
