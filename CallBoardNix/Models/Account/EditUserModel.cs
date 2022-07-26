using System.ComponentModel.DataAnnotations;

namespace CallBoardNix.Models.Account
{
    public class EditUserModel
    {
        [Required]
        [StringLength(35, ErrorMessage = "You must fill your name", MinimumLength = 2)]
        public string? Name { get; set; }
        [Required]
        [StringLength(35, ErrorMessage = "You must fill your surname", MinimumLength = 2)]
        public string? Surname { get; set; }

        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Incorrect data! Example: your1email@poshta.ua")]
        public string? Email { get; set; }
        [Required]
        [RegularExpression(@"\d{10}", ErrorMessage = "Incorrect data! Example:XXXXXXXXXX")]
        public string? PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
