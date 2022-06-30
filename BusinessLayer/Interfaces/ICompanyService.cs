using BusinessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ICompanyService
    {
        Task<CompanyDTO> AddCompany(CompanyDTO model);//добавление компании(функционал работодателя)
        Task<CompanyDTO> EditCompany(CompanyDTO model);//редактировать профиль компании
        Task<AdvertDTO> AddAdvert(AdvertDTO model);//добавить объявление 
        Task<AdvertDTO> DeleteAdvert(AdvertDTO model);//удалить объявление 
        Task<AdvertDTO> EditAdvert(AdvertDTO model);//изменить объявление 
        Task<IEnumerable<AdvertDTO>> GetAdvert();
        Task<IEnumerable<CompanyDTO>> GetCompany();
        Task<IEnumerable<CategoryDTO>> GetCategory();
    }
}
