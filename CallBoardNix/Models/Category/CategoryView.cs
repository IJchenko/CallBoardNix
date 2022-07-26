using System.ComponentModel.DataAnnotations;

namespace CallBoardNix.Models
{
    public class CategoryView
    {
        public Guid IdCategory { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Type the category name!", MinimumLength = 2)]
        public string? CategoryName { get; set; }
    }
}
