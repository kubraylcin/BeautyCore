using BeautyCore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Branches.Queries.GetAllBranches
{
    //Query geldiğinde veritabanına gidip verileri kim getirecek? Tabii ki Handler:
    public class GetAllBranchesQueryHandler: IRequestHandler<GetAllBranchesQuery, List<BranchResponse>>
    //Gelen istek: GetAllBranchesQuery
    //Döneceğim veri: List<BranchResponse> //Bu query gelirse bu handler çalışsın
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetAllBranchesQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<List<BranchResponse>> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
        {
            //request → gelen istek (şu an boş)
            //cancellationToken → işlem iptal edilirse kullanılır
            return await _applicationDbContext.Branches
                .AsNoTracking()// AsNoTracking: Verileri sadece oku, takip etme (HIZ kazandırır)
                .Select(b=> new BranchResponse(
                    //Mapping Entity → DTO dönüşümü Sadece gerekli alanları kullanıcıya veriyorsun
                    b.Id,
                    b.Name,
                    b.Address,
                    b.PhoneNumber))
                .ToListAsync(cancellationToken);
        }
    }
}
