using AutoMapper;
using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using CallBoardNix.Extentions;
using CallBoardNix.Models;
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
        private readonly IMapper _mapper;
        public CompanyController(IMapper mapper, ICompanyService companyService)
        {
            _mapper = mapper;
            _companyService = companyService;
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
            var model = _mapper.Map<AdvertDTO>(advert);
            await _companyService.AddAdvert(model);
            return RedirectToAction("Index", "Home");
        }
    }
}
