using BusinessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IAdminService
    {
        Task AddCategory(CategoryDTO model);
        Task DeleteCategory(Guid guid);
        Task EditCategory(Guid guid ,CategoryDTO model);
    }
}
