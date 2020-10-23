using FluentValidation;

namespace Argos.Domain.CidadeRoot
{
    public class CidadeValidator : AbstractValidator<Cidade>
    {
        public CidadeValidator()
        {
            RuleFor(i => i.CriadoEm);

            RuleFor(i => i.CriadoEm);

            RuleFor(i => i.Nome)
                .NotNull().WithMessage("O campo 'Nome' não pode ser nulo.")
                .NotEmpty().WithMessage("O campo 'Nome' não pode ficar em branco.")
                .MaximumLength(50).WithMessage("O campo 'Nome' aceita apenas 50 caracteres.");

            RuleFor(i => i.EstadoId)
                .NotNull().WithMessage("O campo 'EstadoId' não pode ser nulo.")
                .NotEmpty().WithMessage("O campo 'EstadoId' não pode ficar em branco.");



        }
    }
}