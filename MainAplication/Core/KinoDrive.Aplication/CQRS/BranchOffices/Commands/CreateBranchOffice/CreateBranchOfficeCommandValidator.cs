using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.BranchOffices.Commands.CreateBranchOffice
{
    public class CreateBranchOfficeCommandValidator : AbstractValidator<CreateBranchOfficeCommand>
    {
        public CreateBranchOfficeCommandValidator()
        {
            RuleFor(CreateBranchOfficeCommand =>
                CreateBranchOfficeCommand.Adress).NotEmpty().MaximumLength(255);
        }
    }
}
