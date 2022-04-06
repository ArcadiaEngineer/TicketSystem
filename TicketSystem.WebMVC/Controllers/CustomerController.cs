using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Business.Abstract;
using TicketSystem.Entities.Dtos;
using TicketSystem.WebMVC.Utilities.Extentions;

namespace TicketSystem.WebMVC.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CustomerController : Controller
    {
        ICustomerService _customerService;
        IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        public async Task<IActionResult> GetProfile()
        {
            int customerId = FindCustomerId();
            var customerResult = await _customerService.GetByIdAsync(customerId);
            if (customerResult.Success)
            {
                var customerListingDto = _mapper.Map<CustomerListingDto>(customerResult.Data);
                return View(customerListingDto);
            }
            return RedirectToAction("GetAll", "Movie");
        }
        public async Task<IActionResult> Update()
        {

            int customerId = FindCustomerId();
            var customerResult = await _customerService.GetByIdAsync(customerId);

            if (customerResult.Success)
            {
                var customerUpdateDto = _mapper.Map<CustomerUpdateDto>(customerResult.Data);
                return View(customerUpdateDto);
            }

            return RedirectToAction("GetAll", "Movie");
        }
        [HttpPost]
        public async Task<IActionResult> Update(CustomerUpdateDto customerUpdateDto)
        {
            var customerId = FindCustomerId();
            return await this.UpdateUserAsync(_customerService, _mapper, customerUpdateDto, customerId);
        }

        private int FindCustomerId()
        {
            return Convert.ToInt32(User.FindFirst("Id")!.Value);
        }
    }
}
