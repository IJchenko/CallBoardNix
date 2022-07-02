using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class User
    {
        [Key]
        public Guid IdUser { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        [StringLength(35, ErrorMessage = "You must fill your name", MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [StringLength(35, ErrorMessage = "You must fill your surname", MinimumLength = 2)]
        public string Surname { get; set; }
        [Required]
        [RegularExpression(@"\d{3}-\d{3}-\d{4}", ErrorMessage = "Incorrect data! Example:XXX-XXX-XXXX")]
        public string PhoneNumber { get; set; }
        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Incorrect data! Example: your1email@poshta.ua")]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The password is easy. Must be between 10 and 100 characters", MinimumLength = 10)]
        public string Password { get; set; }
        public Guid IdResumes { get; set; }
        public Guid IdCompany { get; set; }
        public Guid Review { get; set; }
    }
}