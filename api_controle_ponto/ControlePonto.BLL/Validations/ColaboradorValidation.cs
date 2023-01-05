using ControlePonto.Entity.Entities;
using FluentValidation;

namespace ControlePonto.BLL.Validations
{
    public class ColaboradorValidation : AbstractValidator<ColaboradorEntity>
    {
        public ColaboradorValidation()
        {
            RuleFor(c => c.NmColaborador)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 255).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.NrCpf)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(11).WithMessage("O campo {PropertyName} precisa ter 11 caracteres");
        }
    }
}
