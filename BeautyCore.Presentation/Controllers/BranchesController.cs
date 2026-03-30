using BeautyCore.Application.Features.Branches.Commands.CreateBranch;
using BeautyCore.Application.Features.Branches.Queries.GetAllBranches;
using Microsoft.AspNetCore.Mvc;

namespace BeautyCore.Presentation.Controllers
{
    public class BranchesController : ApiBaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateBranchCommand command)
        {
            // MediatR aracılığıyla CreateBranchCommandHandler'ı tetikliyoruz
            var result = await Mediator.Send(command);

            // İşlem başarılıysa yeni oluşan şubenin ID'sini ve 200 OK dönüyoruz
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // MediatR'a "Git bana tüm şubeleri getir" diyoruz.
            var result = await Mediator.Send(new GetAllBranchesQuery());

            return Ok(result);
        }
    }
}
