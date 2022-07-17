using AutoMapper;
using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using CallBoardNix.Extentions;
using CallBoardNix.Models;
using DataLayer.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CallBoardNix.Controllers
{
    [Authorize(Roles = "Employer")]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public CompanyController(IMapper mapper, ICompanyService companyService, IUserService userService)
        {
            _mapper = mapper;
            _companyService = companyService;
            _userService = userService;
        }
        
        [HttpGet]
        public async Task<ActionResult> CreateAdvert()//повертає список всіх категорій
        {
            var model = await _companyService.GetCategory();
            ViewBag.Categories = new SelectList(model, "IdCategory", "CategoryName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAdvert(AdvertView advert)//створює оголошення
        {
            var user = _mapper.Map<User>(await _userService.GetUserByLogin(User.Identity.Name));
            UserViewModel UserModel = new UserViewModel
            {
                IdCompany = user.IdCompany,
            };
            var model = _mapper.Map<AdvertDTO>(advert);
            model.IdCompany = user.IdCompany;
            await _companyService.AddAdvert(model);
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<ActionResult> Company(int page = 1)
        {
            var user = _mapper.Map<User>(await _userService.GetUserByLogin(User.Identity.Name));
            UserViewModel UserModel = new UserViewModel
            {
                IdCompany = user.IdCompany,
            };
            var companys = _mapper.Map<List<CompanyView>>(await _companyService.GetCompany());
            int pageSize = 6;
            var count = companys.Count();
            var items = companys.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            if (UserModel.IdCompany == Guid.Empty)
            {
                CompanyResultModel result = new CompanyResultModel
                (
                    UserModel,
                    items,
                    new PaginationModel(count, page, pageSize)
                );
                return View(result);
            }
            else
            {
                var company = await _companyService.GetCompanyById(UserModel.IdCompany);
                CompanyView companyResult = new CompanyView
                {
                    CompanyName = company.CompanyName,
                    Description = company.Description,
                    Link = company.Link
                };
                CompanyResultModel result = new CompanyResultModel
                (
                    UserModel,
                    companyResult,
                    items,
                    new PaginationModel(count, page, pageSize)
                );
                return View(result);
            }         
        }
        [HttpGet]
        public async Task<ActionResult> CompanyInfo(Guid IdCompany, Guid IdAdvertDelete, int page = 1)
        {
            if (IdAdvertDelete != Guid.Empty)
            { 
                await _companyService.DeleteAdvert(IdAdvertDelete);
            }
            var user = _mapper.Map<User>(await _userService.GetUserByLogin(User.Identity.Name));
            UserViewModel UserModel = new UserViewModel
            {
                IdCompany = user.IdCompany,
            };
            var company = _mapper.Map<CompanyView>(await _companyService.GetCompanyById(IdCompany));
            var adverts = _mapper.Map<List<AdvertView>>(await _companyService.GetAdvertWhere(IdCompany));

            int pageSize = 3;
            var count = adverts.Count();
            var items = adverts.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            CompanyResultModel result = new CompanyResultModel
                (
                    UserModel,
                    company,
                    items,
                    new PaginationModel(count, page, pageSize)
                );
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> EditAdvert(Guid IdAdvert)
        {
            var result = await _companyService.GetAdvertById(IdAdvert);
            var advert = _mapper.Map<AdvertView>(result);
            return View(advert);
        }
        [HttpPost]
        public async Task<IActionResult> EditAdvert(AdvertView model, Guid IdAdvert)
        {
            var advert = _mapper.Map<AdvertDTO>(model);
            await _companyService.EditAdvert(advert, IdAdvert);
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<ActionResult> CreateCompany()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateCompany(CompanyView company)
        {
            var model = _mapper.Map<CompanyDTO>(company);
            model.IdCompany = Guid.NewGuid();
            await _companyService.AddCompany(model);
            await _userService.EditUserCompany(User.Identity.Name, model.IdCompany);
            return RedirectToAction("Company", "Company");
        }
    }
}
