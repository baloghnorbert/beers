using Backend.Core.Modell.Request;
using FluentValidation;

namespace Backend.Validation
{
    public class BeerRequestValidation : AbstractValidator<BeerRequest>
    {
        public BeerRequestValidation()
        {
            RuleFor(x => x.Name).NotEmpty()
                                .NotNull()
                                .WithMessage("Nem megfelelő az objektum azonosítójja!");

            RuleFor(x => x.ImageUrl).NotEmpty()
                                     .NotNull()
                                     .Must(CustomValidators.ValidateUri).WithMessage("Nem valós URL adott meg!");

            RuleFor(x => x.Description).NotEmpty()
                                       .NotNull();
        }
    }
}
