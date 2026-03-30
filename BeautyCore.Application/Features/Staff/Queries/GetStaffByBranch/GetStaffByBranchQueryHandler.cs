using BeautyCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BeautyCore.Application.Features.Staff.Queries.GetStaffByBranch;

public class GetStaffByBranchQueryHandler : IRequestHandler<GetStaffByBranchQuery, List<StaffResponse>>
{
    private readonly IApplicationDbContext _context;

    public GetStaffByBranchQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<StaffResponse>> Handle(GetStaffByBranchQuery request, CancellationToken cancellationToken)
    {
        return await _context.Staffs
            .AsNoTracking()
            .Where(x => x.BranchId == request.BranchId)
            .Select(s => new StaffResponse(
                s.Id,
                $"{s.FirstName} {s.LastName}", // İsim soyisim birleştirme (Server-side)
                s.Title))
            .ToListAsync(cancellationToken);
    }
}
