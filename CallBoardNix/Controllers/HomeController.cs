using BusinessLayer.DTO;
using CallBoardNix.Models;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CallBoardNix.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        AdvertViewModel advert1;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            advert1=new AdvertViewModel()
            {
                NameAdvert = ".Net",
                Description = "text Description",
                Requirements = "text Requirements",
                Salary = "2000",
                company = new Company() { CompanyName = "Nix", Description = "some text desc", Reviews = null, Link = "https://www.nixsolutions.com/ru/", URLImage = null, Users = null, Id = Guid.NewGuid() },
                category = new Category() { Id = Guid.NewGuid(), CategoryName="C#", URLImage=null },
            };
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public string Register(UserDTO model)
        {
            return $"{model.Name}--{model.Surname}--{model.Status}--{model.PhoneNumber}--{model.Email}--{model.Password}--";
        }

        public IActionResult Advert()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Advert(AdvertViewModel advert)
        {
            advert= advert1;
            ViewBag.Advert = advert;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}