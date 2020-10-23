using FluentValidation;

namespace Argos.Domain.CameraLogRoot
{
    public class CameraLogValidator : AbstractValidator<CameraLog>
    {
        public CameraLogValidator()
        {
            RuleFor(i => i.AlertaId)
                .NotNull().WithMessage("O campo 'AlertaId' não pode ser nulo.")
                .NotEmpty().WithMessage("O campo 'AlertaId' não pode ficar em branco.");

            RuleFor(i => i.CameraId)
                .NotNull().WithMessage("O campo 'CameraId' não pode ser nulo.")
                .NotEmpty().WithMessage("O campo 'CameraId' não pode ficar em branco.");

            RuleFor(i => i.Data)
                .NotNull().WithMessage("O campo 'Data' não pode ser nulo.")
                .NotEmpty().WithMessage("O campo 'Data' não pode ficar em branco.");

            RuleFor(i => i.CriadoEm);


        }
    }
}