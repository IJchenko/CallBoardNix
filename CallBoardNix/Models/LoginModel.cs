using System.ComponentModel.DataAnnotations;

namespace CallBoardNix.Models
{
    public class LoginModel
    {
        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Incorrect data! Example: your1email@poshta.ua")]
        public string? Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The password is easy. Must be between 10 and 100 characters", MinimumLength = 10)]
        public string? Password { get; set; }
    }
    public class RegisterModel
    {
        [Required]
        [StringLength(35, ErrorMessage = "You must fill your name", MinimumLength = 2)]
        public string? Name { get; set; }
        [Required]
        [StringLength(35, ErrorMessage = "You must fill your surname", MinimumLength = 2)]
        public string? Surname { get; set; }
        [Required]
        public int status { get; set; }
        [Required]
        [RegularExpression(@"\d{10}", ErrorMessage = "Incorrect data! Example:XXX-XXX-XXXX")]
        public string? PhoneNumber { get; set; }
        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Incorrect data! Example: your1email@poshta.ua")]
        public string? Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The password is easy. Must be between 10 and 100 characters", MinimumLength = 10)]
        public string? Password { get; set; }
    }
}
