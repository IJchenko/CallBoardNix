using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallBoardNix.Models
{
    public class RegisterViewModel
    {
        [Required]
        public int Status { get; set; }
        [Required]
        [StringLength(35, ErrorMessage = "You must fill your name", MinimumLength = 2)]
        public string? Name { get; set; }
        [Required]
        [StringLength(35, ErrorMessage = "You must fill your surname", MinimumLength = 2)]
        public string? Surname { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string? ConfirmPassword { get; set; }
    }
}
