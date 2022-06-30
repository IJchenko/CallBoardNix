using AutoMapper;
using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using CallBoardNix.Models;
using DataLayer.EF;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CallBoardNix.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        public HomeController(ILogger<HomeController> logger, IMapper mapper,IUserService userService,ICompanyService companyService)
        {
            _logger = logger;
            _mapper = mapper;
            _userService = userService;
            _companyService = companyService;
        }
        [HttpGet]
        public async Task<ActionResult<List<AdvertView>>> Index()//повертає список всіх оголошень
        {
            var models = await _companyService.GetAdvert();
            var adverts = new List<AdvertView>();
            foreach(var advert in models)
            {
                adverts.Add(_mapper.Map<AdvertView>(advert));
            }
            return View(adverts);
        }
        [HttpGet]
        public async Task<ActionResult<List<CategoryView>>> CreateAdvert()//повертає список всіх категорій
        {
            var models = await _companyService.GetCategory();
            var categories = new List<CategoryView>();
            foreach(var category in models)
            {
                categories.Add(_mapper.Map<CategoryView>(category));
            }
            ViewBag.Categories = categories;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAdvert(AdvertView advert)//створює оголошення(не створює атрибут категорії)
        {
            var model = _mapper.Map<AdvertDTO>(advert);
            await _companyService.AddAdvert(model);
            return View(advert);
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Advert()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}