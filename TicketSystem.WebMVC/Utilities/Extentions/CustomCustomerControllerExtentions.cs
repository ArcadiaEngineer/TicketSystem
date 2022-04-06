using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Business.Abstract;
using TicketSystem.Entities.Dtos;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.WebMVC.Utilities.Extentions
{
    public static class CustomCustomerControllerExtentions
    {
        public static async Task<IActionResult> UpdateUserAsync(this ControllerBase controller, ICustomerService customerService, IMapper mapper, CustomerUpdateDto customerUpdateDto, int customerId)
        {
            customerUpdateDto.CustomerId = customerId;
            var customer = mapper.Map<Customer>(customerUpdateDto);
            var result = await customerService.UpdateAsync(customer);
            if (result.Success)
            {
                return controller.RedirectToAction("GetProfile");
            }
            return controller.RedirectToAction("Update");
        }

    }
}
