using BeautyCore.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Payments.Commands.CreatePayment
{
    public record CreatePaymentCommand
    (
        Guid AppointmentId,
        decimal Amount,
        string Currency,
        PaymentMethod Method,
        string? TransactionReference) : IRequest<Guid>;
    
}
