using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace TicketSystem.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if(User != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("GetAll","Movie");
            }
            return View();
        }
    }
}
