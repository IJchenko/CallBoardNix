using AutoMapper;
using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using CallBoardNix.Models;
using DataLayer.EF;
using DataLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public async Task<ActionResult> Index()//повертає список всіх оголошень
        {
            string? token = HttpContext.Session.GetString("token");
           
            var model = await _companyService.GetAdvert();
            var adverts = new List<AdvertView>();
            foreach(var advert in model)
            {
                adverts.Add(_mapper.Map<AdvertView>(advert));
            }
            return View(adverts);
        }     
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}