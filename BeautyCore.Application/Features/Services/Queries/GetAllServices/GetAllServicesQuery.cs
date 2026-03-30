using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Services.Queries.GetAllServices
{
    public record GetAllServicesQuery(): IRequest<List<ServiceResponse>>;
    public record ServiceResponse(
        string Name,
        string Description,
        decimal Price,
        int DurationMinutes);
}
