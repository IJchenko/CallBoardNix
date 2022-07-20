using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Advert
    {
        [Key]
        public Guid IdAdvert { get; set; }
        [Required]
        [StringLength(75, ErrorMessage = "The title must be in the range from 2 to 75 symbols", MinimumLength = 2)]
        public string NameAdvert { get; set; }
        [StringLength(2000, MinimumLength = 0)]
        public string Description { get; set; }
        [StringLength(2000, MinimumLength = 0)]
        public string Requirements { get; set; }
        public string Salary { get; set; }
        public Guid IdCompany { get; set; }
        public Guid IdCategory { get; set; }
        public List<Resume> Resume { get; set; } = new List<Resume>();
    }
}