using BeautyCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Appointments.Queries.GetAppointmentsByBranch
{
    public class GetAppointmentsByBranchQueryHandler : IRequestHandler<GetAppointmentsByBranchQuery, List<AppointmentResponse>>
    {
        private readonly IApplicationDbContext _context;

        public GetAppointmentsByBranchQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<AppointmentResponse>> Handle(GetAppointmentsByBranchQuery request, CancellationToken cancellationToken)
        {
            return await _context.Appointments
                .Where(a => a.BranchId == request.BranchId)
                .Include(a => a.Customer)
                .Include(a => a.Staff)
                .Include(a => a.Service)
                .OrderByDescending(a => a.StartAtUtc)
                .Select(a => new AppointmentResponse(
                    a.Id,
                    $"{a.Customer.FirstName} {a.Customer.LastName}",
                    $"{a.Staff.FirstName}{a.Staff.LastName}",
                    a.Service.Name,
                    a.StartAtUtc,
                    a.EndAtUtc,
                    a.Status.ToString(),
                    a.TotalPrice))
                .ToListAsync(cancellationToken);
        }
    }
}
