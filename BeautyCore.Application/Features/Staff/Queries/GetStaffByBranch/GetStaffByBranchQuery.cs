using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Staff.Queries.GetStaffByBranch
{
    public record GetStaffByBranchQuery(Guid BranchId): IRequest<List<StaffResponse>>;
    public record StaffResponse(
        Guid Id,
        string FullName,
        string Title);
    
}
