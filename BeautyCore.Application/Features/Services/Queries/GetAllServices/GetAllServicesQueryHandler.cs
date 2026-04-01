using BeautyCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Services.Queries.GetAllServices
{
    public class GetAllServicesQueryHandler : IRequestHandler<GetAllServicesQuery, List<ServiceResponse>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllServicesQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ServiceResponse>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Services
                .AsNoTracking()
                .Select(b=>new ServiceResponse(
                    b.Id,
                    b.Name,
                    b.Description,
                    b.Price,
                    b.DurationMinutes)).ToListAsync(cancellationToken);
        }
    }
}
