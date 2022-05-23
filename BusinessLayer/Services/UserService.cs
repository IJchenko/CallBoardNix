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
    public class UserService : IUserService
    {
        private readonly IRepository _repository;
        public UserService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResumeDTO> AddResume(ResumeDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "model is empty");
            }
            var resume = model.ToEntity();
            return (await _repository.Create(resume)).ToDTO();
        }
        public async Task<ReviewDTO> AddReviewCompany(ReviewDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "model is empty");
            }
            var review = model.ToEntity();
            return (await _repository.Create(review)).ToDTO();
        }
        public async Task<UserDTO> AddUser(UserDTO model)
        {
            if(model == null)
            {
                throw new ArgumentNullException(nameof(model), "model is empty");
            }
            var user = model.ToEntity();
            return (await _repository.Create(user)).ToDTO();
        }
        public async Task<ResumeDTO> EditResume(ResumeDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "model is empty");
            }
            var resume = model.ToEntity();
            await _repository.Update(resume);
            return resume.ToDTO();
        }
        public async Task<UserDTO> EditUser(UserDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "model is empty");
            }
            var user = model.ToEntity();
            await _repository.Update(user);
            return user.ToDTO();
        }
    }
}
