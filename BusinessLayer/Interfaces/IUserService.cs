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
        Task<ReviewDTO> AddReviewCompany(ReviewDTO model);
        Task<ResumeDTO> AddResume(ResumeDTO model);
        Task<ResumeDTO> EditResume(ResumeDTO model);
        Task<UserDTO> GetUserByLogin(string userName);
        Task<UserDTO> EditUser(UserDTO model);
        Task<UserDTO> EditUserCompany(string login, Guid guid);
    }
}
