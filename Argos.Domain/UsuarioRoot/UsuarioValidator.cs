using FluentValidation;

namespace Argos.Domain.UsuarioRoot
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(i => i.CriadoEm);
            RuleFor(i => i.IsRevoked);

            RuleFor(i => i.Email)
                .NotNull().WithMessage("O campo 'Email' não pode ser nulo.")
                .NotEmpty().WithMessage("O campo 'Email' não pode ficar em branco.")
                .MaximumLength(100).WithMessage("O campo 'Email' aceita apenas 100 caracteres.");

            RuleFor(i => i.Cpf)
                .NotNull().WithMessage("O campo 'Cpf' não pode ser nulo.")
                .NotEmpty().WithMessage("O campo 'Cpf' não pode ficar em branco.")
                .MaximumLength(15).WithMessage("O campo 'Cpf' aceita apenas 15 caracteres.");

            RuleFor(i => i.CriadoEm);

            RuleFor(i => i.TipoId)
                .NotNull().WithMessage("O campo 'TipoId' não pode ser nulo.")
                .NotEmpty().WithMessage("O campo 'TipoId' não pode ficar em branco.");
            

            RuleFor(i => i.Matricula)
                .NotNull().WithMessage("O campo 'Matricula' não pode ser nulo.")
                .NotEmpty().WithMessage("O campo 'Matricula' não pode ficar em branco.")
                .MaximumLength(50).WithMessage("O campo 'Matricula' aceita apenas 50 caracteres.");

            RuleFor(i => i.Nome)
                .NotNull().WithMessage("O campo 'Nome' não pode ser nulo.")
                .NotEmpty().WithMessage("O campo 'Nome' não pode ficar em branco.")
                .MaximumLength(100).WithMessage("O campo 'Nome' aceita apenas 100 caracteres.");

            RuleFor(i => i.Senha)
                .NotNull().WithMessage("O campo 'Senha' não pode ser nulo.")
                .NotEmpty().WithMessage("O campo 'Senha' não pode ficar em branco.")
                .MaximumLength(200).WithMessage("O campo 'Senha' aceita apenas 200 caracteres.");

/**            RuleFor(i => i.PasswordHash)
                .NotNull().WithMessage("O campo 'PasswordHash' não pode ser nulo.")
                .NotEmpty().WithMessage("O campo 'PasswordHash' não pode ficar em branco.")
                .MaximumLength(100).WithMessage("O campo 'PasswordHash' aceita apenas 100 caracteres.");**/


        }
    }
}