using FluentValidation;

namespace Argos.Domain.UsuarioPosicaoRoot
{
    public class UsuarioPosicaoValidator : AbstractValidator<UsuarioPosicao>
    {
        public UsuarioPosicaoValidator()
        {
            RuleFor(i => i.UsuarioId)
                .NotNull().WithMessage("O campo 'UsuarioId' não pode ser nulo.")
                .NotEmpty().WithMessage("O campo 'UsuarioId' não pode ficar em branco.");

            RuleFor(i => i.CriadoEm);

            RuleFor(i => i.Longitude)
                .NotNull().WithMessage("O campo 'Longitude' não pode ser nulo.")
                .NotEmpty().WithMessage("O campo 'Longitude' não pode ficar em branco.");

            RuleFor(i => i.Latitude)
                .NotNull().WithMessage("O campo 'Latitude' não pode ser nulo.")
                .NotEmpty().WithMessage("O campo 'Latitude' não pode ficar em branco.");


        }
    }
}