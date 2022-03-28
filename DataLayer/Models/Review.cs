using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Review
    {
        public Guid Id { get; set; }
        [StringLength(1000, ErrorMessage = "Your review cannot be more than 1000 symbols", MinimumLength = 0)]
        public string Description { get; set; }
        [Required]
        [StringLength(5, MinimumLength = 1)]
        public int Mark { get; set; }
        public List<User> Users { get; set; }
    }
}
