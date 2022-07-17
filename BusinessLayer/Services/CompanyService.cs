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
    public class CompanyService : ICompanyService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public CompanyService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task AddCompany(CompanyDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "model is empty");
            }
            var company = _mapper.Map<Company>(model);
            await _repository.Create(company);
        }
        public async Task EditCompany(CompanyDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "model is empty");
            }
            var company = _mapper.Map<Company>(model);
            await _repository.Update(company);
        }
        public async Task<List<CompanyDTO>> GetCompany()
        {
            var company = _mapper.Map<List<CompanyDTO>>(await _repository.GetAll<Company>());
            return company;
        }
        public async Task DeleteAdvert(Guid IdAdvert)
        {
            await _repository.Delete<Advert>(IdAdvert);
        }
        public async Task EditAdvert(AdvertDTO model,Guid IdAdvert)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "model is empty");
            }
            var advert = await _repository.GetById<Advert>(IdAdvert);
            advert.NameAdvert = model.NameAdvert;
            advert.Description = model.Description;
            advert.Requirements = model.Requirements;
            advert.Salary = model.Salary;
            await _repository.Update(advert);
        }
        public async Task AddAdvert(AdvertDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "model is empty");
            }
            var advert = _mapper.Map<Advert>(model);
            await _repository.Create(advert);
        }
        public async Task<List<AdvertDTO>> GetAdvert()
        {
            var adverts = _mapper.Map<List<AdvertDTO>>(await _repository.GetAll<Advert>());
            return adverts;
        }
        public async Task<List<AdvertDTO>> GetAdvertWhere(Guid guid)
        {
            var adverts = _mapper.Map<List<AdvertDTO>>(await _repository.GetAll<Advert>());
            List<AdvertDTO> result = new List<AdvertDTO>();
            foreach(var advert in adverts)
            {
                if(advert.IdCompany == guid)
                {
                    result.Add(advert);
                }
            }
            return result;
        }
        public async Task<List<CategoryDTO>> GetCategory()
        {
            var categoty = _mapper.Map<List<CategoryDTO>>(await _repository.GetAll<Category>());
            return categoty;
        }

        public async Task<CompanyDTO> GetCompanyById(Guid guid)
        {
            var res = await _repository.GetById<Company>(guid);
            return _mapper.Map<CompanyDTO>(res);
        }
        public async Task<AdvertDTO> GetAdvertById(Guid guid)
        {
            var res = await _repository.GetById<Advert>(guid);
            return _mapper.Map<AdvertDTO>(res);
        }
    }
}            