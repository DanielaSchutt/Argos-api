using FluentValidation;

namespace Argos.Domain.CameraRoot
{
    public class CameraValidator : AbstractValidator<Camera>
    {
        public CameraValidator()
        {
            RuleFor(i => i.CriadoEm);

            RuleFor(i => i.Latitude)
                .NotNull().WithMessage("O campo 'Latitude' não pode ser nulo.")
                .NotEmpty().WithMessage("O campo 'Latitude' não pode ficar em branco.");

            RuleFor(i => i.Status)
                .NotNull().WithMessage("O campo 'Status' não pode ser nulo.")
                .NotEmpty().WithMessage("O campo 'Status' não pode ficar em branco.");

            RuleFor(i => i.Longitude)
                .NotNull().WithMessage("O campo 'Longitude' não pode ser nulo.")
                .NotEmpty().WithMessage("O campo 'Longitude' não pode ficar em branco.");

            RuleFor(i => i.Nome)
                .NotNull().WithMessage("O campo 'Nome' não pode ser nulo.")
                .NotEmpty().WithMessage("O campo 'Nome' não pode ficar em branco.")
                .MaximumLength(150).WithMessage("O campo 'Nome' aceita apenas 150 caracteres.");
            
            RuleFor(i => i.CriadoEm);


        }
    }
}