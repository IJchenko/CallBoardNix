using AutoMapper;
using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using DataLayer.Models;
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
        private readonly IMapper _mapper;
        public UserService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task AddReviewCompany(ReviewDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "model is empty");
            }
            var review = _mapper.Map<Review>(model);
            await _repository.Create(review);
        }
        public async Task EditUser(UserDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "model is empty");
            }
            var user = _mapper.Map<User>(model);
            await _repository.Update(user);
        }
        public async Task EditUserCompany(string login, Guid guid)
        {
            var users = await _repository.GetAll<User>();
            var user = users.FirstOrDefault(x=>x.UserName==login);
            user.IdCompany = guid;
            await _repository.Update(user);
        }
        public async Task AddResume(ResumeDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "model is empty");
            }
            var resume = _mapper.Map<Resume>(model);
            await _repository.Create(resume);
        }
        public async Task EditResume(ResumeDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "model is empty");
            }
            var resume = _mapper.Map<Resume>(model);
            await _repository.Update(resume);
        }
        public async Task<UserDTO> GetUserByLogin(string userName)
        {
            var users = _repository.GetAll<User>();
            User res = new User();
            foreach (var user in await users)
            {
                if(user.UserName == userName)
                {
                    res = user;
                    break;
                }
            }
            if (res == null)
            {
                throw new ArgumentNullException(nameof(res), "model is empty");
            }
            return _mapper.Map<UserDTO>(res);
        }
    }
}
