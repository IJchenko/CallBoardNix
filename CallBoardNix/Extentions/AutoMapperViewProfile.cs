﻿using AutoMapper;
using BusinessLayer.DTO;
using CallBoardNix.Models;
using CallBoardNix.Models.Advert;
using DataLayer.Models;

namespace CallBoardNix.Extentions
{
    public class AutoMapperViewProfile : Profile
    {
        public AutoMapperViewProfile()
        {
            CreateMap<AdvertDTO, AdvertView>().ReverseMap();
            CreateMap<CategoryDTO, CategoryView>().ReverseMap();
            CreateMap<CompanyDTO, CompanyView>().ReverseMap();
            CreateMap<ResumeDTO, ResumeViewModel>().ReverseMap();
        }
    }
}
