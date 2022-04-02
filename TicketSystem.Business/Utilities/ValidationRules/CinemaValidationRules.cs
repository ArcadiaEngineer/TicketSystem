using FluentValidation;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.Business.Utilities.ValidationRules
{
    public class CinemaValidationRules : AbstractValidator<Cinema>
    {
        public CinemaValidationRules()
        {
            RuleFor(c => c.CinemaAddress).NotEmpty().NotEmpty();
            RuleFor(c => c.CinemaName).NotNull().NotEmpty();
        }
    }
}
