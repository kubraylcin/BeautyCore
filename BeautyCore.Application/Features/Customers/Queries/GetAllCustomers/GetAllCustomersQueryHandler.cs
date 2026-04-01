using BeautyCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, List<CustomerResponse>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllCustomersQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CustomerResponse>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Customers
                .AsNoTracking()
                .Select(c => new CustomerResponse(
                    c.Id,
                    $"{c.FirstName} {c.LastName}",
                    c.Email,
                    c.PhoneNumber))
                .ToListAsync(cancellationToken);
        }
    }
}
