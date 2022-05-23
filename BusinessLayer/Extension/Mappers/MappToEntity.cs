using BusinessLayer.DTO;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Extension.Mappers
{
    public static class MappToEntity
    {
        public static Advert ToEntity(this AdvertDTO model)
        {
            Advert modl = new Advert()
            {
                Id = model.Id,
                NameAdvert = model.NameAdvert,
                Description = model.Description,
                Requirements = model.Requirements,
                Salary = model.Salary
            };
            return modl;
        }
        public static Category ToEntity(this CategoryDTO model)
        {
            Category modl = new Category()
            {
                Id = model.Id,
                CategoryName = model.CategoryName,
                URLImage = model.URLImage
            };
            return modl;
        }
        public static Company ToEntity(this CompanyDTO model)
        {
            Company modl = new Company()
            {
                Id = model.Id,
                CompanyName = model.CompanyName,
                Description = model.Description,
                Link = model.Link,
                URLImage = model.URLImage
            };
            return modl;
        }
        public static Resume ToEntity(this ResumeDTO model)
        {
            Resume modl = new Resume()
            {
                Id = model.Id,
                City = model.City,
                Salary = model.Salary,
                Description = model.Description,
                URLImage = model.URLImage
            };
            return modl;
        }
        public static Review ToEntity(this ReviewDTO model)
        {
            Review modl = new Review()
            {
                Id = model.Id,
                Description = model.Description,
                Mark = model.Mark
            };
            return modl;
        }
        public static User ToEntity(this UserDTO model)
        {
            User modl = new User()
            {
                Id = model.Id,
                Status = (DataLayer.Models.StatusType)model.Status,
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
