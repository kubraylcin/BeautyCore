using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCore.Application.Features.Staff.Commands.CreateStaff
{
    public class CreateStaffCommandValidator: AbstractValidator<CreateStaffCommand>
    {
        public CreateStaffCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Personel adı boş olamaz")
                .MinimumLength(2).WithMessage("Personel adı en az 2 karakter olmalıdır");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Personel soyadı boş olamaz");

            RuleFor(x => x.BranchId)
                .NotEmpty().WithMessage("Personelin bir şubeye bağımlı olması zorunludur. ");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Unvan adı boş bırakılamaz. ");
        }
    }
}
