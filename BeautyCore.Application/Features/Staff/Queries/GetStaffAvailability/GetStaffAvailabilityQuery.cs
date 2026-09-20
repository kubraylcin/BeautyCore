using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Staff.Queries.GetStaffAvailability
{
    public record GetStaffAvailabilityQuery(
        Guid StaffId,
        Guid ServiceId,
        DateTime Date) : IRequest<List<string>>;
}
