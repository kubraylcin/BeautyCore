using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Staff.Commands.CreateStaff
{
    public record CreateStaffCommand(
        string FirstName,
        string LastName,
        string Title,
        Guid BranchId):IRequest<Guid>;
    
}
