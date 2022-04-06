using Microsoft.AspNetCore.Mvc;
using TicketSystem.Business.Abstract;

namespace TicketSystem.WebMVC.ViewComponents
{
    public class GetPurchasesComponent : ViewComponent
    {
        IPaymentService _paymentService;

        public GetPurchasesComponent(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int CustomerId)
        {
            var result = await _paymentService.GetAllPaymentOfUser(CustomerId);
            return View("GetPurchasesComponent", result);
        }
    }
}
