using FluentValidation;

namespace Argos.Domain.TipoAlertaRoot
{
    public class TipoAlertaValidator : AbstractValidator<TipoAlerta>
    {
        public TipoAlertaValidator()
        {
            RuleFor(i => i.Descricao)
                .NotNull().WithMessage("O campo 'Descricao' não pode ser nulo.")
                .NotEmpty().WithMessage("O campo 'Descricao' não pode ficar em branco.")
                .MaximumLength(80).WithMessage("O campo 'Descricao' aceita apenas 80 caracteres.");

            




        }
    }
}