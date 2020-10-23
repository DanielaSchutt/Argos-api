using FluentValidation;

namespace Argos.Domain.DispositivoRoot
{
    public class DispositivoValidator : AbstractValidator<Dispositivo>
    {
        public DispositivoValidator()
        {
            RuleFor(i => i.Versao)
                .NotNull().WithMessage("O campo 'Versao' não pode ser nulo.")
                .NotEmpty().WithMessage("O campo 'Versao' não pode ficar em branco.")
                .MaximumLength(10).WithMessage("O campo 'Versao' aceita apenas 10 caracteres.");

            RuleFor(i => i.UsuarioId)
                .NotNull().WithMessage("O campo 'UsuarioId' não pode ser nulo.")
                .NotEmpty().WithMessage("O campo 'UsuarioId' não pode ficar em branco.");

            RuleFor(i => i.CriadoEm);

            RuleFor(i => i.Codigo)
                .NotNull().WithMessage("O campo 'Codigo' não pode ser nulo.")
                .NotEmpty().WithMessage("O campo 'Codigo' não pode ficar em branco.")
                .MaximumLength(200).WithMessage("O campo 'Codigo' aceita apenas 200 caracteres.");


        }
    }
}