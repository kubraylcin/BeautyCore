using BeautyCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Customers.Queries.GetCustomerAppointments
{
    public class GetCustomerAppointmentsQueryHandler : IRequestHandler<GetCustomerAppointmentsQuery, List<CustomerAppointmentDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetCustomerAppointmentsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CustomerAppointmentDto>> Handle(GetCustomerAppointmentsQuery request, CancellationToken cancellationToken)
        {
            var appointments = await _context.Appointments.AsNoTracking()
                .Where(a => a.CustomerId == request.CustomerId)
                .Include(a => a.Service)
                .Include(a => a.Staff)
                .OrderByDescending(a => a.StartAtUtc)
                .Select(a => new CustomerAppointmentDto(
                    a.Id,
                    a.ServiceId,
                    a.Service != null ? a.Service.Name : "Bilinmeyen Hizmet",
                    a.Service != null ? a.Service.Price : 0,
                    a.Service != null ? a.Service.DurationMinutes : 0,
                    a.StaffId,
                    a.Staff != null ? $"{a.Staff.FirstName} {a.Staff.LastName}" : "Bilinmeyen Personel",
                    a.StartAtUtc,
                    a.EndAtUtc,
                    a.Status,
                    a.Note
                    )).ToListAsync(cancellationToken);
            return appointments;
        }
    }
}
