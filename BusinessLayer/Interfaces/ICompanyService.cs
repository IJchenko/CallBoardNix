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
        Task AddCompany(CompanyDTO model);
        Task EditCompany(CompanyDTO model);
        Task AddAdvert(AdvertDTO model);
        Task DeleteAdvert(Guid IdAdvert);
        Task EditAdvert(AdvertDTO model,Guid IdAdvert);
        Task<CompanyDTO> GetCompanyById(Guid guid);
        Task<AdvertDTO> GetAdvertById(Guid guid);
        Task<List<AdvertDTO>> GetAdvertWhere(Guid guid);
        Task<List<AdvertDTO>> GetAdvert();
        Task<List<CompanyDTO>> GetCompany();
        Task<List<CategoryDTO>> GetCategory();
    }
}
