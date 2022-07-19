using AutoMapper;
using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using DataLayer.Models;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class AdminService : IAdminService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public AdminService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task AddCategory(CategoryDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "model is empty");
            }
            var result = _mapper.Map<Category>(model);
            await _repository.Create(result);
        }
        public async Task DeleteCategory(Guid guid)
        {
            await _repository.Delete<Category>(guid);
        }
        public async Task EditCategory(Guid guid, CategoryDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "model is empty");
            }
            var category = await _repository.GetById<Category>(guid);
            category.CategoryName = model.CategoryName;
            await _repository.Update(category);
        }
    }
}