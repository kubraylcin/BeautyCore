using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Services.Commands.CreateService
{
    public record CreateServiceCommand
    (
        string Name,
        string Description,
        decimal Price,
        int DurationMinutes,
         Guid BranchId) : IRequest<Guid>;
}
