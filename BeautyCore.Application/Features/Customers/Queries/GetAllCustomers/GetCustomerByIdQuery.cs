using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Customers.Queries.GetAllCustomers
{
    public record GetCustomerByIdQuery(Guid Id) : IRequest<CustomerDetailResponse>;

    public record CustomerDetailResponse(
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        DateTime? DateOfBirth);
}
