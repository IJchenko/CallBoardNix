using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Resume
    {
        [Key]
        public Guid IdResume { get; set; }
        public string City { get; set; }
        public string Salary { get; set; }
        public string Description { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdCategory { get; set; }
    }
}