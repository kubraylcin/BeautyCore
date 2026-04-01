using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Customers.Queries.GetAllCustomers
{
    public record GetAllCustomersQuery() : IRequest<List<CustomerResponse>>;

    public record CustomerResponse(
        Guid Id,
        string FullName,
        string Email,
        string PhoneNumber);
}
