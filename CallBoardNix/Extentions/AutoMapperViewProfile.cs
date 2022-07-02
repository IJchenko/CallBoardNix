﻿using AutoMapper;
using BusinessLayer.DTO;
using CallBoardNix.Models;
using DataLayer.Models;

namespace CallBoardNix.Extentions
{
    public class AutoMapperViewProfile : Profile
    {
        public AutoMapperViewProfile()
        {
            CreateMap<UserDTO, RegisterModel>().ReverseMap();
            CreateMap<AdvertDTO, AdvertView>().ReverseMap();
            CreateMap<CategoryDTO, CategoryView>().ReverseMap();
        }
    }
}