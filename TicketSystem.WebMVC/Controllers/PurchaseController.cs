using Microsoft.AspNetCore.Mvc;

namespace TicketSystem.WebMVC.Controllers
{
    public class PurchaseController : Controller
    {
        public IActionResult Buy(int id)
        {
            return View();
        }
    }
}
