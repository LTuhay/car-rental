using Car_rental.Models.Domain;
using FluentValidation;

namespace Car_rental.Models.Validators
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(x => x.Make).NotEmpty().WithMessage("Make is required.");
            RuleFor(x => x.Model).NotEmpty().WithMessage("Model is required.");
            RuleFor(x => x.Year).InclusiveBetween(1886, DateTime.Now.Year).WithMessage("Valid Year is required.");
            RuleFor(x => x.PricePerDay).GreaterThan(0).WithMessage("Price per day must be greater than zero.");
            RuleFor(x => x.Location).NotEmpty().WithMessage("Location is required.");
        }
    }
}
