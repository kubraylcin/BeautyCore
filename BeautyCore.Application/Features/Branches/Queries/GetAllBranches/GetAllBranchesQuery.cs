using MediatR;

namespace BeautyCore.Application.Features.Branches.Queries.GetAllBranches
{
    // Okuma işlemi: Dışarıdan parametre almıyor, geriye bir liste DTO dönüyor.
    public record  GetAllBranchesQuery(): IRequest<List<BranchResponse>>; //Bana tüm branch (şube) listesini getir
    // Dış dünyaya (Frontend/Mobile) göndereceğimiz temiz veri modeli
    public record BranchResponse(
        Guid Id,
        string Name,
        string Address,
        string Number);
    
}
