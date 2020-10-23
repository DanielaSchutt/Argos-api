using FluentValidation;

namespace Argos.Domain.EstadoRoot
{
    public class EstadoValidator : AbstractValidator<Estado>
    {
        public EstadoValidator()
        {
            RuleFor(i => i.Nome)
                .NotNull().WithMessage("O campo 'Nome' não pode ser nulo.")
                .NotEmpty().WithMessage("O campo 'Nome' não pode ficar em branco.")
                .MaximumLength(50).WithMessage("O campo 'Nome' aceita apenas 50 caracteres.");

            RuleFor(i => i.CriadoEm);
           


        }
    }
}