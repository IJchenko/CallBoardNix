using AutoMapper;
using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using CallBoardNix.Models;
using CallBoardNix.Models.Advert;
using DataLayer.EF;
using DataLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CallBoardNix.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public HomeController(UserManager<User> userManager, ILogger<HomeController> logger, IMapper mapper,IUserService userService,ICompanyService companyService)
        {
            _logger = logger;
            _mapper = mapper;
            _userService = userService;
            _companyService = companyService;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<ActionResult> Index(int page = 1)//повертає список всіх оголошень
        {
            int pageSize = 7;
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
        public async Task<IActionResult> AdvertInfo(Guid IdAdvert, Guid DeleteResume)
        {
            if (DeleteResume != Guid.Empty)
            {
                await _companyService.DeleteResume(DeleteResume);
            }
            var user = _mapper.Map<User>(await _userManager.FindByNameAsync(User.Identity.Name));
            UserViewModel UserModel = new UserViewModel
            {
                IdCompany = user.IdCompany,
            };
            Guid UserIsICurrent = Guid.Empty;
            if (user.IdCompany != Guid.Empty)
            {
                UserIsICurrent = UserModel.IdCompany;
            }
            var advert = _mapper.Map<AdvertView>(await _companyService.GetAdvertById(IdAdvert));
            var company = _mapper.Map<CompanyView>(await _companyService.GetCompanyById(advert.IdCompany));

            AdvertInfoModel result = new AdvertInfoModel
                (
                    advert,
                    company,
                    UserIsICurrent
                );
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> AddResume(Guid IdAdvert)
        {
            var advert = _mapper.Map<AdvertView>(await _companyService.GetAdvertById(IdAdvert));
            ResumeViewModel result = new ResumeViewModel();
            result.IdAdvert = IdAdvert;
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddResume(ResumeViewModel model)
        {
            if(model != null)
            {
                model.Login = User.Identity.Name;
                await _userService.AddResume(_mapper.Map<ResumeDTO>(model));
                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Input data!");
            }
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}