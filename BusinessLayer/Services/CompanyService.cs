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
        public async Task<CompanyDTO> AddCompany(CompanyDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "model is empty");
            }
            var company = _mapper.Map<Company>(model);
            await _repository.Create(company);
            return _mapper.Map<CompanyDTO>(company);
        }
        public async Task<CompanyDTO> EditCompany(CompanyDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "model is empty");
            }
            var company = _mapper.Map<Company>(model);
            await _repository.Update(company);
            return _mapper.Map<CompanyDTO>(company);
        }
        public async Task<IEnumerable<CompanyDTO>> GetCompany()
        {
            var company = _mapper.Map<IEnumerable<CompanyDTO>>(await _repository.GetAll<Company>());
            return company;
        }
        public async Task<AdvertDTO> DeleteAdvert(AdvertDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "model is empty");
            }
            var advert = _mapper.Map<Advert>(model);
            await _repository.Delete(advert);
            return _mapper.Map<AdvertDTO>(advert);
        }
        public async Task<AdvertDTO> EditAdvert(AdvertDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "model is empty");
            }
            var advert = _mapper.Map<Advert>(model);
            await _repository.Update(advert);
            return _mapper.Map<AdvertDTO>(advert);
        }
        public async Task<AdvertDTO> AddAdvert(AdvertDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "model is empty");
            }
            var advert = _mapper.Map<Advert>(model);
            await _repository.Create(advert);
            return _mapper.Map<AdvertDTO>(advert);
        }
        public async Task<IEnumerable<AdvertDTO>> GetAdvert()
        {
            var adverts = _mapper.Map<IEnumerable<AdvertDTO>>(await _repository.GetAll<Advert>());
            return adverts;
        }
        public async Task<IEnumerable<CategoryDTO>> GetCategory()
        {
            var categoty = _mapper.Map<IEnumerable<CategoryDTO>>(await _repository.GetAll<Category>());
            return categoty;
        }
    }
}
