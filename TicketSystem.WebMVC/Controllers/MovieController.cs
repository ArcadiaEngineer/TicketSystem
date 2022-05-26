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
        ISessionService _sessionService;
        ISceneService _sceneService;

        public MovieController(IMovieService movieService, IMapper mapper, ICategoryService categoryService, ISessionService sessionService, ISceneService sceneService)
        {
            _movieService = movieService;
            _mapper = mapper;
            _categoryService = categoryService;
            _sessionService = sessionService;
            _sceneService = sceneService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string movieName = null, int? categoyId = null, DateTime? vdate = null)
        {

            var categories = await _categoryService.GetAllAsync();
            ViewBag.MovieName = movieName;
            if (categories.Success)
            {
                ViewBag.Categories = categories.Data;
            }



            var result = _movieService.GetMovieByFilters(movieName, categoyId, vdate);

            return View(result.Data);
        }


        public async Task<IActionResult> GetMovie(int id)
        {
            var result = _movieService.GetMovieDetailAsync(id);
            return View(result.Data);
        }

        //[HttpPost]
        //public async Task<IActionResult> GetMoviesByFiltered(int[] categorys, int cinemaId)
        //{
        //    var result = await _movieService.GetAllAsync();
        //    List<Movie> filteredList = result.Data;

        //    var moviesFiltered = (from n in filteredList
        //                          where n.MovieCategoryId.Equals(categorys)
        //                          select n).ToList();

        //    return this.List<MovieListingDto, Movie>(moviesFiltered, _mapper);
        //}

        [Authorize(Roles = "Employee")]
        [HttpGet]
        public async Task<IActionResult> GetListMovies()
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
        [HttpGet]
        public async Task<IActionResult> AddSession()
        {

            var list = await _movieService.GetAllAsync();
            var list2 = await _sceneService.GetAllAsync();
            if (list.Success && list2.Success)
            {
                ViewBag.Movies = new SelectList(list.Data, "MovieId", "MovieName");
                ViewBag.Scenes = new SelectList(list2.Data, "SceneId", "SceneType");
            }

            return View(new Session());
        }
        [Authorize(Roles = "Employee")]
        [HttpPost]
        public async Task<IActionResult> AddSession(Session session)
        {

            var result = await _sessionService.CreateAsync(session);

            if (result.Success)
            {
                return RedirectToAction("GetListMovies");
            }

            return null;
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
                return View("GetListMovies");
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
            return View("GetListMovies");
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
                return RedirectToAction("GetListMovies");
            }

            var result = await _movieService.GetByIdAsync(id);
            if (result.Success)
            {
                var movie = result.Data;
                await _movieService.RemoveAsync(movie);
            }

            return RedirectToAction("GetListMovies");

        }
        private int FindEmployeeId()
        {
            return Convert.ToInt32(User.FindFirst("Id")!.Value);
        }

        public PartialViewResult RecentMovies()
        {
            var result = _movieService.GetMovieByFilters();
            List<Movie> movies= result.Data.OrderByDescending(x => x.MovieId).Take(3).ToList();
           
            return PartialView(movies);
        }

    }
}