using AutoMapper;
using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using CallBoardNix.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CallBoardNix.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAdminService _adminService;
        private readonly ICompanyService _companyService;

        public AdminController(IMapper mapper, IAdminService adminService, ICompanyService companyService)
        {
            _mapper = mapper;
            _adminService = adminService;
            _companyService = companyService;
        }
        [HttpGet]
        public IActionResult AdminPanel()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Category(string sort, Guid IdCategoryDelete)
        {
            if(IdCategoryDelete != Guid.Empty)
            {
                await _adminService.DeleteCategory(IdCategoryDelete);
            }
            var categories = _mapper.Map<List<CategoryView>>(await _companyService.GetCategory());
            IQueryable<CategoryView> result = categories.AsQueryable<CategoryView>();
            result.Include(x => x.CategoryName);
            switch (sort)
            {
                case "Asc":
                    result = result.OrderBy(x => x.CategoryName);
                    break;
                case "Desc":
                    result = result.OrderByDescending(x => x.CategoryName);
                    break;
            }
            return View(result);
        }  
        [HttpGet]
        public IActionResult CategoryCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CategoryCreate(CategoryView model)
        {
            if(model == null)
            {
                ModelState.AddModelError("", "");
            }
            else
            {
                await _adminService.AddCategory(_mapper.Map<CategoryDTO>(model));
                return RedirectToAction("Category", "Admin");
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> CategoryEdit(Guid IdCategory)
        {
            var category = _mapper.Map<CategoryView>(await _companyService.GetCategoryById(IdCategory));
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> CategoryEdit(CategoryView model, Guid IdCategory)
        {
            if (model == null)
            {
                ModelState.AddModelError("", "");
            }
            else
            {
                await _adminService.EditCategory(IdCategory, _mapper.Map<CategoryDTO>(model));
                return RedirectToAction("Category", "Admin");
            }
            return View(model);
        }
    }
}
