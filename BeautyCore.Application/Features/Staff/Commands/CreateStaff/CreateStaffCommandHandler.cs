using BeautyCore.Domain.Interfaces;
using MediatR;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Staff.Commands.CreateStaff
{
    public class CreateStaffCommandHandler : IRequestHandler<CreateStaffCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateStaffCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateStaffCommand request, CancellationToken cancellationToken)
        {
            var staff = new BeautyCore.Domain.Entities.Staff
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Title = request.Title,
                BranchId = request.BranchId,
            };
            _context.Staffs.Add(staff);
            await _context.SaveChangesAsync(cancellationToken);
            return staff.Id;
        }
    }
}
