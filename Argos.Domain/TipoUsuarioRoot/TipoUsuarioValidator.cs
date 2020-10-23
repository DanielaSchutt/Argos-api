using FluentValidation;

namespace Argos.Domain.TipoUsuarioRoot
{
    public class TipoUsuarioValidator : AbstractValidator<TipoUsuario>
    {
        public TipoUsuarioValidator()
        {
            RuleFor(i => i.CriadoEm);

            RuleFor(i => i.Descricao)
                .NotNull().WithMessage("O campo 'Descricao' não pode ser nulo.")
                .NotEmpty().WithMessage("O campo 'Descricao' não pode ficar em branco.")
                .MaximumLength(20).WithMessage("O campo 'Descricao' aceita apenas 20 caracteres.");


        }
    }
}