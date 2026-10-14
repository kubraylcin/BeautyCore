using BeautyCore.Domain.Entities;
using BeautyCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Payments.Commands.CreatePayment
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreatePaymentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            // 1. Randevu var mı kontrol et
            var appointment = await _context.Appointments
                .FirstOrDefaultAsync(a => a.Id == request.AppointmentId, cancellationToken);

            if (appointment == null)
                throw new KeyNotFoundException("Ödeme yapılmak istenen randevu bulunamadı.");

            // 2. Bu randevuya ait daha önce ödeme yapılmış mı kontrol et (One-to-One kuralı)
            var existingPayment = await _context.Payments
                .FirstOrDefaultAsync(p => p.AppointmentId == request.AppointmentId, cancellationToken);

            if (existingPayment != null)
                throw new InvalidOperationException("Bu randevu için zaten bir ödeme kaydedilmiş.");

            // 3. Ödemeyi oluştur
            var payment = new Payment
            {
               
                AppointmentId = request.AppointmentId,
                Amount = request.Amount,
                Currency = string.IsNullOrWhiteSpace(request.Currency) ? "TRY" : request.Currency,
                PaymentDate = DateTime.UtcNow,
                Method = request.Method,
                TransactionReference = request.TransactionReference
            };

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync(cancellationToken);

            return payment.Id;
        }
    }
}
