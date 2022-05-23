using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTO;
using DataLayer.Models;

namespace BusinessLayer.Extension.Mappers
{
    public static class MappToDTO
    {
        public static AdvertDTO ToDTO(this Advert model)
        {
            AdvertDTO modl = new AdvertDTO()
            {
                Id = model.Id,
                NameAdvert =  model.NameAdvert,
                Description = model.Description,
                Requirements = model.Requirements,
                Salary = model.Salary
            };
            return modl;
        }
        public static CategoryDTO ToDTO(this Category model)
        {
            CategoryDTO modl = new CategoryDTO()
            {
                Id = model.Id,
                CategoryName = model.CategoryName,
                URLImage = model.URLImage
            };
            return modl;
        }
        public static CompanyDTO ToDTO(this Company model)
        {
            CompanyDTO modl = new CompanyDTO()
            {
                Id = model.Id,
                CompanyName = model.CompanyName,
                Description = model.Description,
                Link = model.Link,
                URLImage = model.URLImage
            };
            return modl;
        }
        public static ResumeDTO ToDTO(this Resume model)
        {
            ResumeDTO modl = new ResumeDTO()
            {
                Id = model.Id,
                City = model.City,
                Salary = model.Salary,
                Description = model.Description,
                URLImage = model.URLImage
            };
            return modl;
        }
        public static ReviewDTO ToDTO(this Review model)
        {
            ReviewDTO modl = new ReviewDTO()
            {
                Id = model.Id,
                Description = model.Description,
                Mark = model.Mark
            };
            return modl;
        }
        public static UserDTO ToDTO(this User model)
        {
            UserDTO modl = new UserDTO()
            {
                Id = model.Id,
                Status = (DTO.StatusType)model.Status,
                Name = model.Name,
                Surname = model.Surname,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Password = model.Password,
            };
            return modl;
        }
    }
}
