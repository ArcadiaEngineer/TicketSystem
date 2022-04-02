using Microsoft.AspNetCore.Mvc;

namespace TicketSystem.WebMVC.ViewComponents
{
    public class IntroducingComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("IntroducingComponent");
        }
    }
}
