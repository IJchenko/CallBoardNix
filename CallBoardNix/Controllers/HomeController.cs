using AutoMapper;
using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using CallBoardNix.Models;
using CallBoardNix.Models.Advert;
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
        public async Task<ActionResult> Index(int page = 1)//повертає список всіх оголошень
        {
            string? token = HttpContext.Session.GetString("token");
            int pageSize = 6;
            var adverts = _mapper.Map<List<AdvertView>>(await _companyService.GetAdvert());
            var count = adverts.Count();
            var items = adverts.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            ListOfAdvert listOfAdvert = new ListOfAdvert
            (
                new PaginationModel(count, page, pageSize),
                items
            );
            return View(listOfAdvert);
        }    
        [HttpGet]
        public async Task<IActionResult> AdvertInfo(Guid IdAdvert)
        {
            var advert = _mapper.Map<AdvertView>(await _companyService.GetAdvertById(IdAdvert));
            var company = _mapper.Map<CompanyView>(await _companyService.GetCompanyById(advert.IdCompany));
            AdvertInfoModel result = new AdvertInfoModel
                (
                    advert,
                    company
                );
            return View(result);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}