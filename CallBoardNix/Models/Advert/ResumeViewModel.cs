using System.ComponentModel.DataAnnotations;

namespace CallBoardNix.Models.Advert
{
    public class ResumeViewModel
    {
        public Guid IdResume { get; set; }
        [Required]
        [StringLength(2000, ErrorMessage = "Type the resume text!", MinimumLength = 10)]
        public string? Description { get; set; }
        public string? Login { get; set; }
        public Guid IdAdvert { get; set; }
        public AdvertView? Advert { get; set; }
    }
}
