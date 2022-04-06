using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketSystem.Business.Abstract;
using TicketSystem.Entities.Dtos;
using TicketSystem.Entities.SystemEntities;
using TicketSystem.WebMVC.Utilities.Extentions;

namespace TicketSystem.WebMVC.Controllers
{
    public class MovieController : Controller
    {
        IMovieService _movieService;
        IMapper _mapper;
        ICategoryService _categoryService;

        public MovieController(IMovieService movieService, IMapper mapper, ICategoryService categoryService)
        {
            _movieService = movieService;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _movieService.GetAllAsync();
            return this.List<MovieListingDto, Movie>(result, _mapper);
        }

        [Authorize(Roles = "Employee")]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var list = await _categoryService.GetAllAsync();

            if (list.Success)
            {
                ViewBag.Categories = new SelectList(list.Data, "CategoryId", "CategoryName");
            }

            return View(new MovieCreateDto());
        }

        [Authorize(Roles = "Employee")]
        [HttpPost]
        public async Task<IActionResult> Add(MovieCreateDto movieCreateDto, IFormFile formFile)
        {
            var employeeId = FindEmployeeId();
            movieCreateDto.EmployeeId = employeeId;
            return await this.CreateMovie(movieCreateDto, _mapper, formFile, _movieService);
        }

        [Authorize(Roles = "Employee")]
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            if (id == 0)
            {
                return View("GetAll");
            }
            var result = await _movieService.GetByIdAsync(id);
            if (result.Success)
            {
                var list = await _categoryService.GetAllAsync();

                if (list.Success)
                {
                    ViewBag.Categories = new SelectList(list.Data, "CategoryId", "CategoryName");
                }

                var movieUpdateDto = _mapper.Map<MovieUpdateDto>(result.Data);
                return View(movieUpdateDto);
            }
            return View("GetAll");
        }

        [Authorize(Roles = "Employee")]
        [HttpPost]
        public async Task<IActionResult> Update(MovieUpdateDto movieUpdateDto, IFormFile formFile)
        {
            var employeeId = FindEmployeeId();
            movieUpdateDto.EmployeeId = employeeId;
            return await this.UpdateMovie(movieUpdateDto, _mapper, formFile, _movieService);
        }

        [Authorize(Roles = "Employee")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("GetAll");
            }

            var result = await _movieService.GetByIdAsync(id);
            if (result.Success)
            {
                var movie = result.Data;
                await _movieService.RemoveAsync(movie);
            }

            return RedirectToAction("GetAll");

        }
        private int FindEmployeeId()
        {
            return Convert.ToInt32(User.FindFirst("Id")!.Value);
        }
    }
}