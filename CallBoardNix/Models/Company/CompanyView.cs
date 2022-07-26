using DataLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace CallBoardNix.Models
{
    public class CompanyView
    {
        public Guid IdCompany { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "You must fill your company name", MinimumLength = 2)]
        public string? CompanyName { get; set; }
        [Required]
        [StringLength(1500, ErrorMessage = "Type the description!", MinimumLength = 10)]
        public string? Description { get; set; }
        [Required]
        public string? Link { get; set; }
    }
}
