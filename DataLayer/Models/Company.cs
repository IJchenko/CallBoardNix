using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Company
    {
        [Key]
        public Guid IdCompany { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
    }
}