﻿using CallBoardNix.Models.Advert;
using DataLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace CallBoardNix.Models
{
    public class AdvertView
    {
        public Guid IdAdvert { get; set; }
        public string? NameAdvert { get; set; }
        public string? Description { get; set; }
        public string? Requirements { get; set; }
        public int? Salary { get; set; }
        public Guid IdCompany { get; set; }
        public Guid IdCategory { get; set; }
        public List<ResumeViewModel>? Resume { get; set; }
    }
}
