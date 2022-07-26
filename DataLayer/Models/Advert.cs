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
        public string NameAdvert { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public int Salary { get; set; }
        public Guid IdCompany { get; set; }
        public Guid IdCategory { get; set; }
        public List<Resume> Resume { get; set; } = new List<Resume>();
    }
}