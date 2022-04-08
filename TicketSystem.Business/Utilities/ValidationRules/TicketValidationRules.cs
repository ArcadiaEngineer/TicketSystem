using FluentValidation;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.Business.Utilities.ValidationRules
{
    public class TicketValidationRules : AbstractValidator<Ticket>
    {
        public TicketValidationRules()
        {
            RuleFor(t => t.CustomerId).NotEmpty().NotNull().GreaterThanOrEqualTo(1);
            RuleFor(t => t.SessionId).NotEmpty().NotNull().GreaterThanOrEqualTo(1);
            RuleFor(t => t.AdultNum).Null().NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(t => t.StudentNum).Null().NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(t => t.Price).NotNull().GreaterThanOrEqualTo(0).NotEmpty();

        }
    }
}
