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
        public string Description { get; set; }
        public string Login { get; set; }
        public Guid IdAdvert { get; set; }
        public Advert Advert { get; set; }
    }
}