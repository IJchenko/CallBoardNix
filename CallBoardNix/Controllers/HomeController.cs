using BusinessLayer.DTO;
using CallBoardNix.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CallBoardNix.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}