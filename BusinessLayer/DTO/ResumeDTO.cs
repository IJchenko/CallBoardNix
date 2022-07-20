using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class ResumeDTO
    {
        public Guid IdResume { get; set; }
        public string Description { get; set; }
        public string Login { get; set; }
        public Guid IdAdvert { get; set; }
        public AdvertDTO Advert { get; set; }
    }
}
