using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DataLayer.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string Status { get; set; }
        [Required]
        [StringLength(35, ErrorMessage = "You must fill your name", MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [StringLength(35, ErrorMessage = "You must fill your surname", MinimumLength = 2)]
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Guid IdResumes { get; set; }
        public Guid IdCompany { get; set; }
    }
}