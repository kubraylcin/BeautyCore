using BeautyCore.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Customers.Queries.GetCustomerAppointments
{
    public record CustomerAppointmentDto(
    Guid Id,
    Guid ServiceId,
    string ServiceName,
    decimal ServicePrice,
    int DurationMinutes,
    Guid StaffId,
    string StaffFullName,
    DateTime StartAtUtc,
    DateTime EndAtUtc,
    AppointmentStatus Status,
    string? Notes);

    public record GetCustomerAppointmentsQuery(Guid CustomerId) : IRequest<List<CustomerAppointmentDto>>;
}
