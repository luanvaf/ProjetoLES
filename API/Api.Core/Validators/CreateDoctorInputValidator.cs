using Domain.Dtos.Inputs;
using FluentValidation;

namespace Api.Core.Validators
{
    public class CreateDoctorInputValidator : AbstractValidator<DtoCreateDoctorInput>
    {
        public CreateDoctorInputValidator()
        {
            RuleFor(x => x.Crm).NotEmpty().NotEmpty().WithMessage("A crm não pode ser vazia ou nula.");
            RuleFor(x => x.Password).NotEmpty().NotEmpty().WithMessage("A senha não pode ser vazia ou nula.");
            RuleFor(x => x.CompleteName).NotEmpty().NotEmpty().WithMessage("O nome não pode ser vazio ou nulo.");
        }
    }
}
