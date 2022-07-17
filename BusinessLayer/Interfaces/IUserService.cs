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
        Task AddReviewCompany(ReviewDTO model);
        Task AddResume(ResumeDTO model);
        Task EditResume(ResumeDTO model);
        Task<UserDTO> GetUserByLogin(string userName);
        Task EditUser(UserDTO model);
        Task EditUserCompany(string login, Guid guid);
    }
}
