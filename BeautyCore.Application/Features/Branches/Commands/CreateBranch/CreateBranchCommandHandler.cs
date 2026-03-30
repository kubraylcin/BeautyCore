using BeautyCore.Domain.Entities;
using BeautyCore.Domain.Interfaces;
using BeautyCore.Persistence.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Branches.Commands.CreateBranch
{
    public class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateBranchCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            // 1. Yeni entity oluştur
            var branch = new Branch
            {
                Name = request.Name,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber
            };

            // 2. Veritabanına ekle
            _context.Branches.AddAsync(branch,cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            // 3. ID'yi geri dön
            return branch.Id;
        }
    }
}
