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
            var advert = await _repository.GetById<Advert>(model.IdAdvert);
            var resume = _mapper.Map<Resume>(model);        
            resume.Advert = advert;
            await _repository.Create(resume);
        }
    }
}
