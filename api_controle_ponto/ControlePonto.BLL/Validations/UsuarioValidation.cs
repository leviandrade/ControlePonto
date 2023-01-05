using ControlePonto.Entity.Entities;
using FluentValidation;

namespace ControlePonto.BLL.Validations
{
    public class UsuarioValidation : AbstractValidator<UsuarioEntity>
    {
        public UsuarioValidation()
        {
            RuleFor(c => c.NmUsuario)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 255).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.NrCpf)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(11).WithMessage("O campo {PropertyName} precisa ter 11 caracteres");

            RuleFor(c => c.Senha)
                .NotEmpty().WithMessage("O campo {PropertyName} ser fornecido");
        }
    }
}
