using AutoMapper;
using BusinessLayer.Interfaces;
using CallBoardNix.Extentions;
using CallBoardNix.Models;
using DataLayer.EF;
using DataLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CallBoardNix.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _userService = userService;
            _roleManager = roleManager;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            await InitializerEntity.InitializeAsync(_userManager, _roleManager);
            if (ModelState.IsValid)
            {
                User user = new User() { Name = model.Name, UserName = model.UserName, Surname = model.Surname, 
                Status = model.Status, Email = model.Email, PhoneNumber = model.PhoneNumber,EmailConfirmed = true };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if (user.Status == "Worker")
                    {
                        _userManager.AddToRoleAsync(user, "Worker").Wait();
                    }
                    if (user.Status == "Employer")
                    {
                        _userManager.AddToRoleAsync(user, "Employer").Wait();
                    }
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                if (result.Succeeded)
                {
                    var user = _mapper.Map<User>(await _userManager.FindByNameAsync(model.UserName));
                    var token = CreateToken(user.Status);
                    HttpContext.Session.SetString("Token", token);
                    return RedirectToAction("Index", "Home");
                }
                else ModelState.AddModelError("", "Wrong login or password");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Profile(bool change = false)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
           
            UserViewModel res = new UserViewModel
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                IdCompany = user.IdCompany,
                IdResumes = user.IdResumes,
                UserName = user.UserName
            };
            return View(res);
        }
        public string CreateToken(string role)
        {
            var claims = new List<Claim>
            {
            new Claim(ClaimTypes.Role, role),
            };
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(3)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
