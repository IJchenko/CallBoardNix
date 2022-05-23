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
        Task<UserDTO> AddUser(UserDTO model);//Регистрация нового пользователя
        Task<UserDTO> EditUser(UserDTO model);//Изменить инфу о пользователе
        Task<ReviewDTO> AddReviewCompany(ReviewDTO model);//оставить отзыв на компанию(для исполнителей)
        Task<ResumeDTO> AddResume(ResumeDTO model);//добавление резюме
        Task<ResumeDTO> EditResume(ResumeDTO model);//редактировать резюме
    }
}
