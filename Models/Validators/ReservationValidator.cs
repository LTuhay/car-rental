using Car_rental.Models.Domain;
using FluentValidation;

namespace Car_rental.Models.Validators
{
    public class ReservationValidator : AbstractValidator<Reservation>
    {
        public ReservationValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User ID is required.");
            RuleFor(x => x.CarId).NotEmpty().WithMessage("Car ID is required.");
            RuleFor(x => x.StartDate).GreaterThanOrEqualTo(DateTime.Today).WithMessage("Start date must be today or later.");
            RuleFor(x => x.EndDate).GreaterThan(x => x.StartDate).WithMessage("End date must be after start date.");
            RuleFor(x => x.TotalPrice).GreaterThan(0).WithMessage("Total price must be greater than zero.");
        }
    }
}
