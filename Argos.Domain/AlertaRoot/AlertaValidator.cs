using FluentValidation;

namespace Argos.Domain.AlertaRoot
{
    public class AlertaValidator : AbstractValidator<Alerta>
    {
        public AlertaValidator()
        {
            RuleFor(i => i.CidadeId)
                .NotNull().WithMessage("O campo 'CidadeId' não pode ser nulo.")
                .NotEmpty().WithMessage("O campo 'CidadeId' não pode ficar em branco.");

            RuleFor(i => i.CriadoEm);

            RuleFor(i => i.TipoId)
                .NotNull().WithMessage("O campo 'TipoId' não pode ser nulo.")
                .NotEmpty().WithMessage("O campo 'TipoId' não pode ficar em branco.");

            RuleFor(i => i.Titulo)
                .NotNull().WithMessage("O campo 'Titulo' não pode ser nulo.")
                .NotEmpty().WithMessage("O campo 'Titulo' não pode ficar em branco.")
                .MaximumLength(150).WithMessage("O campo 'Titulo' aceita apenas 150 caracteres.");

            RuleFor(i => i.Placa)
                .NotNull().WithMessage("O campo 'Placa' não pode ser nulo.")
                .NotEmpty().WithMessage("O campo 'Placa' não pode ficar em branco.")
                .MaximumLength(10).WithMessage("O campo 'Placa' aceita apenas 10 caracteres.");

            RuleFor(i => i.Area)
                .MaximumLength(500).WithMessage("O campo 'Area' aceita apenas 500 caracteres.");

            RuleFor(i => i.Status);
            RuleFor(i => i.UsuarioId);
        }
    }
}