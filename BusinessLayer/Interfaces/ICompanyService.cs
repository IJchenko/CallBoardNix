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
        Task<CompanyDTO> AddCompany(CompanyDTO model);
        Task<CompanyDTO> EditCompany(CompanyDTO model);
        Task<AdvertDTO> AddAdvert(AdvertDTO model);
        Task<AdvertDTO> DeleteAdvert(AdvertDTO model);
        Task<AdvertDTO> EditAdvert(AdvertDTO model);
        Task<CompanyDTO> GetCompanyById(Guid id);
        Task<IEnumerable<AdvertDTO>> GetAdvert();
        Task<IEnumerable<CompanyDTO>> GetCompany();
        Task<IEnumerable<CategoryDTO>> GetCategory();
    }
}
