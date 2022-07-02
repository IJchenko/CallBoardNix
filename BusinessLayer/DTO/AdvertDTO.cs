using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class AdvertDTO
    {
        public Guid IdAdvert { get; set; }
        public string NameAdvert { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string Salary { get; set; }
        public Guid IdCompany { get; set; }
        public Guid IdCategory { get; set; }
    }
}
