using Domain.Dtos.Inputs;
using FluentValidation;

namespace Api.Core.Validators
{
    public class CreateProfessorInputValidator : AbstractValidator<DtoCreateProfessorInput>
    {
        public CreateProfessorInputValidator()
        {
            RuleFor(x => x.CompleteName).NotNull().NotEmpty().WithMessage("O nome não pode ser vazio ou nulo.");
            RuleFor(x => x.Crm).NotNull().NotEmpty().WithMessage("A crm não pode ser vazia ou nula.");
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("A senha não pode ser vazia ou nula.");
            RuleFor(x => x.Titulation).NotNull().NotEmpty().WithMessage("A titulação não pode ser vazia ou nula.");
        }
    }
}
