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
    [Authorize(Roles = "Employee")]
    public class Employee : Controller
    {
        ISessionService _sessionService;
        IMapper _mapper;
        IMovieService _movieService;
        IEmployeeService _employeeService;
        ISceneService _sceneService;

        public Employee(IMapper mapper, ISessionService sessionService, IMovieService movieService, IEmployeeService employeeService, ISceneService sceneService)
        {
            _mapper = mapper;
            _sessionService = sessionService;
            _movieService = movieService;
            _employeeService = employeeService;
            _sceneService = sceneService;
        }

        public async Task<IActionResult> GetProfile()
        {
            var employeeId = FindEmployeeId();
            var employeeResult = await _employeeService.GetByIdAsync(employeeId);
            if (employeeResult.Success)
            {
                var employeeListingDto = _mapper.Map<EmployeeListingDto>(employeeResult.Data);
                return View(employeeListingDto);
            }
            return RedirectToAction("GetAll", "Movie");
        }

        [HttpGet]
        public async Task<IActionResult> AddSession()
        {
            var moviesResult = await _movieService.GetAllAsync();
            var sceneResult = await _sceneService.GetAllAsync();
            if (moviesResult.Success && sceneResult.Success)
            {
                ViewBag.Movies = new SelectList(moviesResult.Data, "MovieId", "MovieName");
                ViewBag.Scenes = new SelectList(sceneResult.Data, "SceneId", "SceneName");
            }
            return View(new SessionCreateDto());
        }
        [HttpPost]
        public async Task<IActionResult> AddSession(SessionCreateDto sessionCreateDto)
        {
            var session = _mapper.Map<Session>(sessionCreateDto);
            var sessionResult = await _sessionService.CreateAsync(session);
            if (sessionResult.Success)
            {
                return View("GetAll", "Movie");
            }
            return View("AddSession");
        }

        public async Task<IActionResult> Update()
        {

            int employeeId = FindEmployeeId();
            var employeeResult = await _employeeService.GetByIdAsync(employeeId);

            if (employeeResult.Success)
            {
                var employeeUpdateDto = _mapper.Map<EmployeeUpdateDto>(employeeResult.Data);
                return View(employeeUpdateDto);
            }

            return RedirectToAction("GetAll", "Movie");
        }
        [HttpPost]
        public async Task<IActionResult> Update(EmployeeUpdateDto employeeUpdateDto)
        {
            var employeeId = FindEmployeeId();
            return await this.UpdateUserAsync(_employeeService, _mapper, employeeUpdateDto, employeeId);
        }

        private int FindEmployeeId() => Convert.ToInt32(User.FindFirst("Id")!.Value);
    }
}
