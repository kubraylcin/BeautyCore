using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Appointments.Queries.GetAppointmentsByBranch
{
    public record  GetAppointmentsByBranchQuery(Guid BranchId):IRequest<List<AppointmentResponse>>;

    public record AppointmentResponse(
        Guid Id,
    string CustomerName,
    string StaffName,
    string ServiceName,
    DateTime StartAtUtc,
    DateTime EndAtUtc,
    string Status,
    decimal TotalPrice);
}
