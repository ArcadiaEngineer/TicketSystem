using FluentValidation;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.Business.Utilities.ValidationRules
{
    public class PaymentValidationRules : AbstractValidator<Payment>
    {
        public PaymentValidationRules()
        {
            RuleFor(p => p.CustomerId).NotNull().NotEmpty().GreaterThanOrEqualTo(1);
            RuleFor(p => p.CVV).NotNull().NotEmpty();
            RuleFor(p => p.CardUserName).NotEmpty().NotNull();
            RuleFor(p => p.CardId).NotNull().NotEmpty();
            RuleFor(p => p.CardDueDate).NotNull().NotEmpty();
            RuleFor(p => p.EInvoice).NotNull().NotEmpty();
        }
    }
}
