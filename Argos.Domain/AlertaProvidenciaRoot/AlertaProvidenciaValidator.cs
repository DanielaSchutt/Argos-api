using FluentValidation;

namespace Argos.Domain.AlertaProvidenciaRoot
{
    public class AlertaProvidenciaValidator : AbstractValidator<AlertaProvidencia>
    {
        public AlertaProvidenciaValidator()
        {
            RuleFor(i => i.Descricao)
                .NotNull().WithMessage("O campo 'Descricao' não pode ser nulo.")
                .NotEmpty().WithMessage("O campo 'Descricao' não pode ficar em branco.")
                .MaximumLength(500).WithMessage("O campo 'Descricao' aceita apenas 500 caracteres.");

            RuleFor(i => i.CriadoEm);


            RuleFor(i => i.AlertaId)
                .NotNull().WithMessage("O campo 'AlertaId' não pode ser nulo.")
                .NotEmpty().WithMessage("O campo 'AlertaId' não pode ficar em branco.");


        }
    }
}