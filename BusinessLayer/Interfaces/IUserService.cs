using BusinessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IUserService
    {
        Task AddResume(ResumeDTO model);
        Task EditUserCompany(string login, Guid guid);
    }
}
