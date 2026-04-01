using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Customers.Commands.CreateCustomer
{
    public record CreateCustomerCommand(
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        DateTime? DateOfBirth):IRequest<Guid>;
    
}
