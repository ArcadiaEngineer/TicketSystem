using FluentValidation;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.Business.Utilities.ValidationRules
{
    public class SceneValidationRules : AbstractValidator<Scene>
    {
        public SceneValidationRules()
        {
            RuleFor(s => s.SceneType).NotEmpty().NotNull();
            RuleFor(s => s.SceneName).NotEmpty().NotNull();
            RuleFor(s => s.CinemaId).NotEmpty().NotNull().GreaterThanOrEqualTo(1);
        }
    }
}
