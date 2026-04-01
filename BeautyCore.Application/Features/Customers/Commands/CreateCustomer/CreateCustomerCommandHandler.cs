using BeautyCore.Domain.Entities;
using BeautyCore.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler: IRequestHandler<CreateCustomerCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateCustomerCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                DateOfBirth = request.DateOfBirth
            };
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync(cancellationToken);
            return customer.Id;
        }
    }
}
