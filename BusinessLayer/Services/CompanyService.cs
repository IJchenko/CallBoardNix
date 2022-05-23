using BusinessLayer.DTO;
using BusinessLayer.Extension.Mappers;
using BusinessLayer.Interfaces;
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
        public CompanyService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<CompanyDTO> AddCompany(CompanyDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "model is empty");
            }
            var company = model.ToEntity();
            return(await _repository.Create(company)).ToDTO();
        }
        public async Task<CompanyDTO> EditCompany(CompanyDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "model is empty");
            }
            var company = model.ToEntity();
            await _repository.Update(company);
            return company.ToDTO();
        }
        public async Task<AdvertDTO> DeleteAdvert(AdvertDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "model is empty");
            }
            var advert = model.ToEntity();
            await _repository.Delete(advert);
            return advert.ToDTO();
        }
        public async Task<AdvertDTO> EditAdvert(AdvertDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "model is empty");
            }
            var advert = model.ToEntity();
            await _repository.Update(advert);
            return advert.ToDTO();
        }
        public async Task<AdvertDTO> AddAdvert(AdvertDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "model is empty");
            }
            var advert = model.ToEntity();
            return (await _repository.Create(advert)).ToDTO();
        }
    }
}
