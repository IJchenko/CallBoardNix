using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Company
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public List<Review> Reviews { get; set; }
        public List<User> Users { get; set; }
        public string URLImage { get; set; }
    }
}