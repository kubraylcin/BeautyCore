using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Branches.Commands.CreateBranch
{
    //record=Immutable (değiştirilemez) veri taşır
    public record CreateBranchCommand (
        string Name,
        string Address,
        string PhoneNumber
        ): IRequest<Guid>; //Bu komut çalışınca bana Guid dönecek  yaanii yeni oluşturulan Branch’in ID’si dönecek

}
